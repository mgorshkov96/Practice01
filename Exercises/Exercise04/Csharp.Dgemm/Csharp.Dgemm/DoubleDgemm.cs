using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Dgemm
{
    public class DoubleDgemm : IDgemm
    {
        private double alpha;
        private double beta;
        private double[,] matrixA;
        private double[,] matrixB;
        private double[,] matrixC;
        Reader reader;

        public DoubleDgemm(Reader reader)
        {
            this.reader = reader;
            ConvertValues();          
        }

        public void ConvertValues()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            try
            {
                matrixA = new double[reader.MatrixSize, reader.MatrixSize];
                matrixB = new double[reader.MatrixSize, reader.MatrixSize];
                matrixC = new double[reader.MatrixSize, reader.MatrixSize];

                alpha = Double.Parse(reader.Alpha);
                beta = Double.Parse(reader.Beta);
                matrixA = ConvertMatrixToDouble(reader.MatrixA);
                matrixB = ConvertMatrixToDouble(reader.MatrixB);
                matrixC = ConvertMatrixToDouble(reader.MatrixC);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public double[,] ConvertMatrixToDouble(string[,] strMatrix)
        {
            double[,] matrix = new double[reader.MatrixSize, reader.MatrixSize];
            try
            {
                for (int i = 0; i < reader.MatrixSize; i++)
                {
                    for (int j = 0; j < reader.MatrixSize; j++)
                    {
                        matrix[i, j] = Double.Parse(strMatrix[i, j]);
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

        public string[] ConvertMatrixToString(double[,] matrix)
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


        public double[,] MultiplyMatrixByMatrix(double[,] firstMat, double[,] secondMat)
        {
            double[,] resultMatrix = new double[reader.MatrixSize, reader.MatrixSize];

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

        public double[,] MultiplyScalarByMatrix(double scal, double[,] mat)
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

        public double[,] AddMatrices(double[,] firstMat, double[,] secondMat)
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

