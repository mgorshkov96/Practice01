using System;
using System.IO;

namespace Csharp.Dgemm
{
    public class Writer
    {
        public void Write(string path, string[] matrix)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (string s in matrix) 
                    {
                        sw.WriteLine(s);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
