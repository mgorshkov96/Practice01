using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Dgemm
{
    public class Factory
    {
        public IDgemm Create(Reader reader)
        {
            switch (reader.ValueType)
            {
                case "Int": return new IntDgemm(reader);
                case "Double": return new DoubleDgemm(reader);
                case "BigInt": return new BigIntDgemm(reader);
                default: return null;
            }
        }
    }
}
