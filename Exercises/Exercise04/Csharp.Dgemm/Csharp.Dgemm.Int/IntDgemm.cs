using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Dgemm.Int
{
    public class IntDgemm
    {
        static void Main(string[] args)
        {
            int alpha = 2;
            int beta = 5;           
            int[,] matrixA = { { 1, 4, 9 }, { 5, 14, 158 }, { 256, 147, 518 } };
            int[,] matrixB = { { 14, 54, 8 }, { 46, 41, 7 }, { 5, 37, 12 } };
            int[,] matrixC = { { 14, 54, 8 }, { 46, 41, 7 }, { 5, 37, 12 } };
            matrixC = AddMatrices(MultiplyMatrixByMatrix(MultiplyScalarByMatrix(alpha, matrixA), matrixB), MultiplyScalarByMatrix(beta, matrixC));

            for (int i = 0; i < matrixC.GetLength(0); i++)
            {
                for (int j = 0; j < matrixC.GetLength(1); j++)
                {
                    Console.Write(matrixC[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[,] MultiplyMatrixByMatrix(int[,] firstMat, int[,] secondMat)
        {
            int[,] resultMatrix = new int[firstMat.GetLength(0), secondMat.GetLength(1)];

            for (int m = 0; m < firstMat.GetLength(0); m++)
            {
                for (int n = 0; n < secondMat.GetLength(1); n++)
                {
                    for (int k = 0; k < secondMat.GetLength(0); k++)
                    {
                        resultMatrix[m, n] += firstMat[m, k] * secondMat[k, n];
                    }
                }
            }

            return resultMatrix;
        }

        public static int[,] MultiplyScalarByMatrix(int scal, int[,] mat)
        {
            for (int m = 0; m < mat.GetLength(0); m++)
            {
                for (int n = 0; n < mat.GetLength(1); n++)
                {
                    mat[m, n] = mat[m, n] * scal;
                }
            }

            return mat;
        }

        public static int[,] AddMatrices(int[,] firstMat, int[,] secondMat)
        {
            for (int m = 0; m < firstMat.GetLength(0); m++)
            {
                for (int n = 0; n < secondMat.GetLength(0); n++)
                {
                    firstMat[m, n] += secondMat[m, n];
                }
            }

            return firstMat;
        }
    }
}
