using System;
using System.IO;

namespace Csharp.Dgemm
{
    public class Reader
    {
        private string valueType;
        private int matrixSize;
        private string alpha;
        private string beta;
        private string[,] matrixA;
        private string[,] matrixB;
        private string[,] matrixC;
        private string matrixCPath;

        public string ValueType { get { return valueType; } }
        public int MatrixSize { get { return matrixSize;} }
        public string Alpha { get { return alpha; } }
        public string Beta { get { return beta;} }
        public string[,] MatrixA { get { return matrixA;} }
        public string[,] MatrixB { get { return matrixB; } }
        public string[,] MatrixC { get { return matrixC; } }
        public string MatrixCPath { get { return matrixCPath; } }

        public void Read()
        {
            try
            {
                string valueTypePath = "..\\..\\..\\..\\Data\\value_type.txt";
                string matrixSizePath = "..\\..\\..\\..\\Data\\matrix_size.txt";
                string alphaPath = "..\\..\\..\\..\\Data\\alpha.txt";
                string betaPath = "..\\..\\..\\..\\Data\\beta.txt";
                string matrixAPath = "..\\..\\..\\..\\Data\\matrix_a.txt";
                string matrixBPath = "..\\..\\..\\..\\Data\\matrix_b.txt";
                matrixCPath = "..\\..\\..\\..\\Data\\matrix_c.txt";

                using(StreamReader sr = new StreamReader(valueTypePath))
                {
                    valueType = sr.ReadLine();
                }

                using (StreamReader sr = new StreamReader(matrixSizePath))
                {
                    matrixSize = Int32.Parse(sr.ReadLine());
                }

                matrixA = new string[matrixSize, matrixSize];
                matrixB = new string[matrixSize, matrixSize];
                matrixC = new string[matrixSize, matrixSize];

                using (StreamReader sr = new StreamReader(alphaPath))
                {
                    alpha = sr.ReadLine();
                }

                using (StreamReader sr = new StreamReader(betaPath))
                {
                    beta = sr.ReadLine();
                }

                using (StreamReader sr = new StreamReader(matrixAPath))
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] container = line.Split(' ');
                        int j = 0;
                        foreach (string s in container)
                        {
                            matrixA[i, j] = s;
                            j++;
                        }
                        i++;
                    }
                }

                using (StreamReader sr = new StreamReader(matrixBPath))
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] container = line.Split(' ');
                        int j = 0;
                        foreach (string s in container)
                        {
                            matrixB[i, j] = s;
                            j++;
                        }
                        i++;
                    }
                }

                using (StreamReader sr = new StreamReader(matrixCPath))
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] container = line.Split(' ');
                        int j = 0;
                        foreach (string s in container)
                        {
                            matrixC[i, j] = s;
                            j++;
                        }
                        i++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
