import matplotlib.pyplot as plt
import csv

MATRIX_SIZES = [25, 50, 100, 200]


def write_time(dict, arr):
    if dict["matrix_size"] == "25":
        arr[0] = int(dict["time"])
    elif dict["matrix_size"] == "50":
        arr[1] = int(dict["time"])
    elif dict["matrix_size"] == "100":
        arr[2] = int(dict["time"])
    elif dict["matrix_size"] == "200":
        arr[3] = int(dict["time"])


pythonInt = [0, 0, 0, 0]
pythonDouble = [0, 0, 0, 0]
pythonBigInt = [0, 0, 0, 0]
javaInt = [0, 0, 0, 0]
javaDouble = [0, 0, 0, 0]
javaBigInt = [0, 0, 0, 0]
csharpInt = [0, 0, 0, 0]
csharpDouble = [0, 0, 0, 0]
csharpBigInt = [0, 0, 0, 0]

with open("Results/results.csv") as file:
    reader = csv.DictReader(file)
    for row in reader:
        if row["language"] == "python" and row["value_type"] == "Int":
            write_time(row, pythonInt)
        elif row["language"] == "python" and row["value_type"] == "Double":
            write_time(row, pythonDouble)
        elif row["language"] == "python" and row["value_type"] == "BigInt":
            write_time(row, pythonBigInt)
        elif row["language"] == "java" and row["value_type"] == "Int":
            write_time(row, javaInt)
        elif row["language"] == "java" and row["value_type"] == "Double":
            write_time(row, javaDouble)
        elif row["language"] == "java" and row["value_type"] == "BigInt":
            write_time(row, javaBigInt)
        elif row["language"] == "csharp" and row["value_type"] == "Int":
            write_time(row, csharpInt)
        elif row["language"] == "csharp" and row["value_type"] == "Double":
            write_time(row, csharpDouble)
        elif row["language"] == "csharp" and row["value_type"] == "BigInt":
            write_time(row, csharpBigInt)

dpi = 80
intFig = plt.figure(dpi=dpi, figsize=(512 / dpi, 384 / dpi))

plt.plot(MATRIX_SIZES, pythonInt, "go-")
plt.plot(MATRIX_SIZES, javaInt, "ro-")
plt.plot(MATRIX_SIZES, csharpInt, "bo-")
plt.title("Integer")
plt.xlabel("Matrix size (a * a)")
plt.ylabel("Lead time (ms)")

plt.legend(["python",
            "java",
            "csharp"], loc="upper left")

intFig.savefig("Results/int_type.png")

doubleFig = plt.figure(dpi=dpi, figsize=(512 / dpi, 384 / dpi))
plt.plot(MATRIX_SIZES, pythonDouble, "go-")
plt.plot(MATRIX_SIZES, javaDouble, "ro-")
plt.plot(MATRIX_SIZES, csharpDouble, "bo-")
plt.title("Double")
plt.xlabel("Matrix size (a * a)")
plt.ylabel("Lead time (ms)")

plt.legend(["python",
            "java",
            "csharp"], loc="upper left")

doubleFig.savefig("Results/double_type.png")

bigIntFig = plt.figure(dpi=dpi, figsize=(512 / dpi, 384 / dpi))
plt.plot(MATRIX_SIZES, pythonBigInt, "go-")
plt.plot(MATRIX_SIZES, javaBigInt, "ro-")
plt.plot(MATRIX_SIZES, csharpBigInt, "bo-")
plt.title("Big integer")
plt.xlabel("Matrix size (a * a)")
plt.ylabel("Lead time (ms)")

plt.legend(["python",
            "java",
            "csharp"], loc="upper left")

bigIntFig.savefig("Results/bigint_type.png")
