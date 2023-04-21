using System;
using System.Text;
using System.Numerics;

namespace Csharp.Dgemm
{
    public class BigIntDgemm : IDgemm
    {
        private BigInteger alpha;
        private BigInteger beta;
        private BigInteger[,] matrixA;
        private BigInteger[,] matrixB;
        private BigInteger[,] matrixC;
        Reader reader;

        public BigIntDgemm(Reader reader)
        {
            this.reader = reader;
            ConvertValues();
        }

        public void ConvertValues()
        {
            try
            {
                matrixA = new BigInteger[reader.MatrixSize, reader.MatrixSize];
                matrixB = new BigInteger[reader.MatrixSize, reader.MatrixSize];
                matrixC = new BigInteger[reader.MatrixSize, reader.MatrixSize];

                alpha = BigInteger.Parse(reader.Alpha);
                beta = BigInteger.Parse(reader.Beta);
                matrixA = ConvertMatrixToBigInt(reader.MatrixA);
                matrixB = ConvertMatrixToBigInt(reader.MatrixB);
                matrixC = ConvertMatrixToBigInt(reader.MatrixC);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public BigInteger[,] ConvertMatrixToBigInt(string[,] strMatrix)
        {
            BigInteger[,] matrix = new BigInteger[reader.MatrixSize, reader.MatrixSize];
            try
            {
                for (int i = 0; i < reader.MatrixSize; i++)
                {
                    for (int j = 0; j < reader.MatrixSize; j++)
                    {
                        matrix[i, j] = BigInteger.Parse(strMatrix[i, j]);
                    }
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            return matrix;
        }

        public string[] GetAnswer()
        {
            return ConvertMatrixToString(matrixC);
        }

        public string[] ConvertMatrixToString(BigInteger[,] matrix)
        {
            string[] result = new string[reader.MatrixSize];
            for (int i = 0; i < reader.MatrixSize; i++)
            {
                StringBuilder sr = new StringBuilder();
                for (int j = 0; j < reader.MatrixSize; j++)
                {
                    sr.Append(matrix[i, j] + " ");
                }
                result[i] = sr.ToString().Trim();
            }
            return result;
        }

        public void CalculateDgemm()
        {
            matrixC = AddMatrices(MultiplyMatrixByMatrix(MultiplyScalarByMatrix(alpha, matrixA), matrixB), MultiplyScalarByMatrix(beta, matrixC));
        }


        public BigInteger[,] MultiplyMatrixByMatrix(BigInteger[,] firstMat, BigInteger[,] secondMat)
        {
            BigInteger[,] resultMatrix = new BigInteger[reader.MatrixSize, reader.MatrixSize];

            for (int m = 0; m < reader.MatrixSize; m++)
            {
                for (int n = 0; n < reader.MatrixSize; n++)
                {
                    for (int k = 0; k < reader.MatrixSize; k++)
                    {
                        resultMatrix[m, n] += firstMat[m, k] * secondMat[k, n];
                    }
                }
            }

            return resultMatrix;
        }

        public BigInteger[,] MultiplyScalarByMatrix(BigInteger scal, BigInteger[,] mat)
        {
            for (int m = 0; m < reader.MatrixSize; m++)
            {
                for (int n = 0; n < reader.MatrixSize; n++)
                {
                    mat[m, n] = mat[m, n] * scal;
                }
            }
            return mat;
        }

        public BigInteger[,] AddMatrices(BigInteger[,] firstMat, BigInteger[,] secondMat)
        {
            for (int m = 0; m < reader.MatrixSize; m++)
            {
                for (int n = 0; n < reader.MatrixSize; n++)
                {
                    firstMat[m, n] += secondMat[m, n];
                }
            }
            return firstMat;
        }
    }
}

