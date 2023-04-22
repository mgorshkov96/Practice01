import random


def generate_matrix(size, min_v, max_v, type_v):
    matrix = [[0 for __ in range(size)] for __ in range(size)]
    if type_v == "Int" or type_v == "BigInt":
        for i in range(size):
            for j in range(size):
                matrix[i][j] = random.randint(min_v, max_v)
    else:
        for i in range(size):
            for j in range(size):
                matrix[i][j] = random.uniform(min_v, max_v)
    return matrix


def generate_scalar(min_v, max_v, type_v):
    if type_v == "Int" or type_v == "BigInt":
        return random.randint(min_v, max_v)
    else:
        return random.uniform(min_v, max_v)


def enter_values():
    mat_size = int(input("Введите размер матриц (a * a), a: "))
    val_type_number = int(input("Введите номер типа данных (Int - 1/Double - 2/BigInt - 3): "))
    val_type = ""

    if val_type_number == 1:
        val_type = "Int"
    elif val_type_number == 2:
        val_type = "Double"
    elif val_type_number == 3:
        val_type = "BigInt"

    min_val = int(input("Введите минимальное целое значение: "))
    max_val = int(input("Введите максимальное целое значение: "))
    return mat_size, val_type, min_val, max_val


def write_value(value, path):
    with open(path, "w") as file:
        file.write(str(value))


def write_matrix(matrix, path):
    size = len(matrix[0])
    with open(path, "w") as file:
        for i in range(size):
            line = ""
            for j in range(size):
                line = line + str(matrix[i][j]) + " "
            file.write(line.strip() + "\n")


matrix_size, value_type, min_value, max_value = enter_values()

alpha = generate_scalar(min_value, max_value, value_type)
beta = generate_scalar(min_value, max_value, value_type)
matrix_a = generate_matrix(matrix_size, min_value, max_value, value_type)
matrix_b = generate_matrix(matrix_size, min_value, max_value, value_type)
matrix_c = generate_matrix(matrix_size, min_value, max_value, value_type)

write_value(alpha, "Data/alpha.txt")
write_value(beta, "Data/beta.txt")
write_value(matrix_size, "Data/matrix_size.txt")
write_value(value_type, "Data/value_type.txt")
write_matrix(matrix_a, "Data/matrix_a.txt")
write_matrix(matrix_b, "Data/matrix_b.txt")
write_matrix(matrix_c, "Data/matrix_c.txt")
