import math
import random


def enter_values():
    try:
        distance_to_water = float(input("Введите кратчайшее расстояние от спасателя до кромки воды (в ярдах): "))
        distance_to_coast = float(input("Введите кратчайшее расстояние от утопающего до берега (в футах): "))
        distance_to_drowning = float(input("Введите боковое смещение между утопающим и спасателем (в ярдах): "))
        speed_on_sand = float(input("Введите скорость движения спасателя по песку (в милях в час): "))
        water_coef = float(input("Введите коэффициент замедления спасателя при движении в воде: "))
        first_degree = float(input("Введите направление движения спасателя по песку (в градусах): "))

        entered_values = {"Дистанция до воды": distance_to_water, "Дистанция до берега": distance_to_coast,
                          "Дистанция до утопающего": distance_to_drowning, "Скорость на песке": speed_on_sand,
                          "Коэфициент скорости в воде": water_coef, "Угол начала движения": first_degree}
        return entered_values
    except ValueError:
        print("Можно вводить только числа. Попробуйте еще раз ;)")


def convert_to_radian(degree):
    return degree * math.pi/180


def get_opposite_leg(radian, distance):
    return distance * math.tan(radian)


def get_hypotenuse(leg1, leg2):
    return math.sqrt(leg1 ** 2 + leg2 ** 2)


def get_time_to_drowning(speed, path1, path2, coef):
    return (1 / speed) * (path1 + path2 * coef)


def calculate_values(distance_to_water, distance_to_coast, distance_to_drowning, speed_on_sand, water_coef, degree):
    distance_to_water = distance_to_water / (5280 / 3)
    distance_to_coast = distance_to_coast / 5280
    distance_to_drowning = distance_to_drowning / (5280 / 3)
    first_radian = convert_to_radian(degree)
    distance_to_water_point = get_opposite_leg(first_radian, distance_to_water)
    sand_path = get_hypotenuse(distance_to_water, distance_to_water_point)
    water_path = get_hypotenuse((distance_to_drowning - distance_to_water_point), distance_to_coast)
    result_time = get_time_to_drowning(speed_on_sand, sand_path, water_path, water_coef) * 3600
    result = {"Угол": degree, "Время": result_time}
    return result


def print_answer(degree, time):
    print("Если спасатель начнет движение под углом theta1, равным {:d} градусам, он достигнет утопающего "
          "через {:.1f} секунды".format(int(degree), time))


# Подбор оптимального угла
best_time = 0
best_degree = 0
degree = 0
epsilon = 0.01

while 0 - epsilon < degree < 90 + epsilon:
    calculated_values = calculate_values(8, 10, 50, 5, 2, degree)
    degree = degree + 0.1
    if best_time == 0:
        best_time = calculated_values["Время"]
        best_degree = calculated_values["Угол"]
    elif best_time > calculated_values["Время"]:
        best_time = calculated_values["Время"]
        best_degree = calculated_values["Угол"]

print("Оптимальный угол {:.2f} градуса(ов). Спасатель достигнет утопоющего "
      "через {:.1f} секунды.".format(best_degree, best_time))
