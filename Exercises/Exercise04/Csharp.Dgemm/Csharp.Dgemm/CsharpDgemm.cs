using System;

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
