using System;
using System.Diagnostics;

namespace Csharp.Dgemm
{
    public class CsharpDgemm
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();
            reader.Read();            
            Factory factory= new Factory();
            IDgemm dgemm = factory.Create(reader);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100; i++) 
            {
                dgemm.CalculateDgemm();
            }
            sw.Stop();

            long result_time = sw.ElapsedMilliseconds;

            Writer writer = new Writer();
            writer.Write(result_time, reader.MatrixSize, reader.ValueType);

            //if (dgemm != null)
            //{
            //    dgemm.CalculateDgemm();
            //    Writer writer = new Writer();
            //    writer.Write(reader.MatrixCPath, dgemm.GetAnswer());
            //}
            //else
            //{
            //    Console.WriteLine("Тип данных не распознан, попробуйте еще раз.");
            //}                
        }
    }
}
