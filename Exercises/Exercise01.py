import math

distance_to_water = float(input("Введите кратчайшее расстояние от спасателя до кромки воды (в ярдах): "))/(5280 / 3)
distance_to_coast = float(input("Введите кратчайшее расстояние от утопающего до берега (в футах): "))/5280
distance_to_drowning = float(input("Введите боковое смещение между утопающим и спасателем (в ярдах): "))/(5280 / 3)
speed_on_sand = float(input("Введите скорость движения спасателя по песку (в милях в час): "))
water_coef = float(input("Введите коэффициент замедления спасателя при движении в воде: "))
first_degree = float(input("Введите направление движения спасателя по песку (в градусах): "))


def convert_to_radian(degree):
    return degree * math.pi/180


def get_opposite_leg(radian, distance):
    return distance * math.tan(radian)


def get_hypotenuse(leg1, leg2):
    return math.sqrt(leg1 ** 2 + leg2 ** 2)


def get_time_to_drowning(speed, path1, path2, coef):
    return (1 / speed) * (path1 + path2 * coef)


first_radian = convert_to_radian(first_degree)
distance_to_water_point = get_opposite_leg(first_radian, distance_to_water)
sand_path = get_hypotenuse(distance_to_water, distance_to_water_point)
water_path = get_hypotenuse((distance_to_drowning - distance_to_water_point), distance_to_coast)
result_time = get_time_to_drowning(speed_on_sand, sand_path, water_path, water_coef) * 3600
print("Если спасатель начнет движение под углом theta1, равным {:d} градусам, он достигнет утопающего "
      "через {:.1f} секунды".format(int(first_degree), result_time))

