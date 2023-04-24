using System;
using System.Text;

namespace Csharp.Dgemm
{
    public class IntDgemm : IDgemm
    {
        private int alpha;
        private int beta;
        private int[,] matrixA;
        private int[,] matrixB;
        private int[,] matrixC;
        Reader reader;

        public IntDgemm(Reader reader)
        {
            this.reader = reader;
            ConvertValues();
        }

        public void ConvertValues()
        {
            try
            {
                matrixA = new int[reader.MatrixSize, reader.MatrixSize];
                matrixB = new int[reader.MatrixSize, reader.MatrixSize];
                matrixC = new int[reader.MatrixSize, reader.MatrixSize];

                alpha = Int32.Parse(reader.Alpha);
                beta = Int32.Parse(reader.Beta);
                matrixA = ConvertMatrixToInt(reader.MatrixA);
                matrixB = ConvertMatrixToInt(reader.MatrixB);
                matrixC = ConvertMatrixToInt(reader.MatrixC);
            } 
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);                 
            }
        }

        public int[,] ConvertMatrixToInt(string[,] strMatrix)
        {
            int[,] matrix = new int[reader.MatrixSize, reader.MatrixSize];
            try
            {               
                for (int i = 0; i < reader.MatrixSize; i++)
                {
                    for (int j = 0; j < reader.MatrixSize; j++)
                    {
                        matrix[i, j] = Int32.Parse(strMatrix[i, j]);
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

        public string[] ConvertMatrixToString(int[,] matrix)
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
        

        public int[,] MultiplyMatrixByMatrix(int[,] firstMat, int[,] secondMat)
        {
            int[,] resultMatrix = new int[reader.MatrixSize, reader.MatrixSize];

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

        public int[,] MultiplyScalarByMatrix(int scal, int[,] mat)
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

        public int[,] AddMatrices(int[,] firstMat, int[,] secondMat)
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
