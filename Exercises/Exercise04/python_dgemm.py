def multiply_matrix_by_matrix(mat_a, mat_b):
    m = len(mat_a)
    n = len(mat_b[0])
    k = len(mat_b)

    result_matrix = [[0 for __ in range(n)] for __ in range(m)]

    for indx_m in range(m):
        for indx_n in range(n):
            for indx_k in range(k):
                result_matrix[indx_m][indx_n] += mat_a[indx_m][indx_k] * mat_b[indx_k][indx_n]

    return result_matrix


def multiply_scalar_by_matrix(scal, mat):
    m = len(mat)
    n = len(mat[0])

    for indx_m in range(m):
        for indx_n in range(n):
            mat[indx_m][indx_n] = mat[indx_m][indx_n] * scal

    return mat


def add_matrices(mat_a, mat_b):
    m = len(mat_a)
    n = len(mat_b[0])

    for indx_m in range(m):
        for indx_n in range(n):
            mat_a[indx_m][indx_n] += mat_b[indx_m][indx_n]

    return mat_a


alpha = 2
beta = 5
matrix_a = [[1, 4, 9], [5, 14, 158], [256, 147, 518]]
matrix_b = [[14, 54, 8], [46, 41, 7], [5, 37, 12]]
matrix_c = [[14, 54, 8], [46, 41, 7], [5, 37, 12]]

matrix_c = add_matrices(multiply_matrix_by_matrix(multiply_scalar_by_matrix(alpha, matrix_a), matrix_b),
                        multiply_scalar_by_matrix(beta, matrix_c))
print(matrix_c)


