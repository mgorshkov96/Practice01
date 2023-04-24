import time
import csv


def multiply_matrix_by_matrix(mat_a, mat_b):
    m = len(mat_a)
    n = len(mat_b[0])
    k = len(mat_b)

    result_matrix = [[0 for __ in range(n)] for __ in range(m)]

    for idx_m in range(m):
        for idx_n in range(n):
            for idx_k in range(k):
                result_matrix[idx_m][idx_n] += mat_a[idx_m][idx_k] * mat_b[idx_k][idx_n]

    return result_matrix


def multiply_scalar_by_matrix(scal, mat):
    m = len(mat)
    n = len(mat[0])

    result_matrix = [[0 for __ in range(n)] for __ in range(m)]

    for idx_m in range(m):
        for idx_n in range(n):
            result_matrix[idx_m][idx_n] = mat[idx_m][idx_n] * scal

    return result_matrix


def add_matrices(mat_a, mat_b):
    m = len(mat_a)
    n = len(mat_b[0])

    result_matrix = [[0 for __ in range(n)] for __ in range(m)]

    for idx_m in range(m):
        for idx_n in range(n):
            result_matrix[idx_m][idx_n] += mat_b[idx_m][idx_n]

    return result_matrix


def read():
    with open("Data/alpha.txt") as alpha_file:
        f_scalar = alpha_file.read()
    with open("Data/beta.txt") as beta_file:
        s_scalar = beta_file.read()
    with open("Data/value_type.txt") as value_type_file:
        val_type = value_type_file.read()
    with open("Data/matrix_size.txt") as matrix_size_file:
        mat_size = int(matrix_size_file.read())

    first_mat = read_matrix("Data/matrix_a.txt", mat_size)
    second_mat = read_matrix("Data/matrix_b.txt", mat_size)
    third_mat = read_matrix("Data/matrix_c.txt", mat_size)
    return f_scalar, s_scalar, val_type, mat_size, first_mat, second_mat, third_mat


def read_matrix(path, size):
    result = [[0 for __ in range(size)] for __ in range(size)]
    i = 0
    with open(path) as file:
        for line in file:
            container = line.split()
            for j in range(size):
                result[i][j] = container[j]
            i += 1
    return result


def convert_values(first_scalar, second_scalar, v_type, size, first_mat, second_mat, third_mat):
    try:
        if v_type == "Int" or v_type == "BigInt":
            first_scalar = int(first_scalar)
            second_scalar = int(second_scalar)
            first_mat = convert_matrix_to_int(first_mat, size)
            second_mat = convert_matrix_to_int(second_mat, size)
            third_mat = convert_matrix_to_int(third_mat, size)
        else:
            first_scalar = float(first_scalar)
            second_scalar = float(second_scalar)
            first_mat = convert_matrix_to_float(first_mat, size)
            second_mat = convert_matrix_to_float(second_mat, size)
            third_mat = convert_matrix_to_float(third_mat, size)
        return first_scalar, second_scalar, v_type, size, first_mat, second_mat, third_mat
    except ValueError:
        print("Не удалось преобразовать значения")


def convert_matrix_to_int(matrix, size):
    result = [[0 for __ in range(size)] for __ in range(size)]

    for i in range(size):
        for j in range(size):
            result[i][j] = int(matrix[i][j])
    return result


def convert_matrix_to_float(matrix, size):
    result = [[0 for __ in range(size)] for __ in range(size)]
    for i in range(size):
        for j in range(size):
            result[i][j] = float(matrix[i][j])
    return result


def write(matrix, size):
    with open("Data/matrix_c.txt", "w") as file:
        for i in range(size):
            line = ""
            for j in range(size):
                line = line + str(matrix[i][j]) + " "
            file.write(line.strip() + "\n")


alpha_str, beta_str, value_type_str, matrix_size_str, matrix_a_str, matrix_b_str, matrix_c_str = read()

alpha, beta, value_type, matrix_size, matrix_a, matrix_b, matrix_c = \
    convert_values(alpha_str, beta_str, value_type_str, matrix_size_str, matrix_a_str, matrix_b_str, matrix_c_str)

start_time = time.time()

for idx in range(100):
    result = add_matrices(multiply_matrix_by_matrix(multiply_scalar_by_matrix(alpha, matrix_a), matrix_b),
                          multiply_scalar_by_matrix(beta, matrix_c))

end_time = time.time()
result_time = (end_time - start_time) * 1000

data = [{
    "language": "python",
    "value_type": value_type,
    "matrix_size": matrix_size,
    "time": result_time
}]

with open("Results/results.csv", "a", newline="") as file:
    writer = csv.DictWriter(file, fieldnames=list(data[0].keys()), quoting=csv.QUOTE_NONNUMERIC)
    writer.writerow(data[0])



