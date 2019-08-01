using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairLibary
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInts = new int[] { 1, 9, 3, 4, 5, 6, 2, 9 };

            Pairs[] returnValue = Pairs.DivisiblePairs(arrayInts);
            Console.WriteLine("Divisible pairs with duplication:");
            returnValue.ToList().ForEach(x => Console.WriteLine(string.Format("{0} div {1}", x.Dividend, x.Divider)));

            Console.WriteLine("----");
            Console.WriteLine("Divisible pairs without duplication:");
            returnValue = Pairs.DivisiblePairs(arrayInts, true);

            returnValue.ToList().ForEach(x => Console.WriteLine(string.Format("{0} div {1}", x.Dividend, x.Divider)));

            Console.WriteLine("----");
            Console.WriteLine("Divisible pairs without duplication and without by themselveso:");
            // Despresar os divisiveis por ele mesmo
            returnValue = Pairs.DivisiblePairs(arrayInts, true, false);

            returnValue.ToList().ForEach(x => Console.WriteLine(string.Format("{0} div {1}", x.Dividend, x.Divider)));
            Console.ReadKey();
        }
    }
}

