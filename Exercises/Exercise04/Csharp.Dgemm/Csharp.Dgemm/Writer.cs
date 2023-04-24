using System;
using System.IO;
using System.Text;

namespace Csharp.Dgemm
{
    public class Writer
    {
        public void Write(long time, int matrix_size, string value_type)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("..\\..\\..\\..\\Results\\results.csv", true))
                {
                    StringBuilder result = new StringBuilder();
                    result.Append("csharp");
                    result.Append(",");
                    result.Append(value_type);
                    result.Append(",");
                    result.Append(matrix_size);
                    result.Append(",");
                    result.Append(time);

                    sw.Write(result.ToString() + "\n");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
