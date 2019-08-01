using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairLibary
{
    public class ArrayIntNullException : Exception
    {
        public ArrayIntNullException() : base("Integer array cannot be null.") { }
    }
}
