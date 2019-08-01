using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairLibary
{
    public class DivisiblePairsException : Exception
    {
        public DivisiblePairsException(Exception innerException) : base("Unexpected error calculating divisible pairs.", innerException) { }
    }
}
