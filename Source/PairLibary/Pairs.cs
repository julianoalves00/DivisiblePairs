using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairLibary
{

    public class Pairs
    {
        public int Dividend { get; set; }
        public int Divider { get; set; }

        // An array of integers returns all pairs in which one of the numbers is divisible by the other.. 
        public static Pairs[] DivisiblePairs(int[] arrayInt, bool removerDuplicacoes = false, bool divisivelPorEleMesmo = true)
        {
            if (arrayInt == null)
                throw new ArrayIntNullException();

            Pairs[] returnValue = null;
            try
            {
                int p = 0;
                // Remove the zeros, and turn it into Dictionary
                var itens01 = arrayInt.Where(y => y != 0).ToDictionary(x => p++, x => x);

                List<Pairs> listaPares = new List<Pairs>();

                itens01.ToList().ForEach(item =>
                                            listaPares.AddRange(itens01.Where(x => (item.Key != x.Key || divisivelPorEleMesmo) &&
                                                                    (item.Value % x.Value) == 0)
                                                                    .Select(y => new Pairs { Dividend = item.Value, Divider = y.Value })
                                                                    .ToArray())
                                        );

                if (removerDuplicacoes)
                    listaPares = listaPares.Distinct(new PairsComparer()).ToList();

                returnValue = listaPares.ToArray();
            }
            catch (Exception ex)
            {
                throw new DivisiblePairsException(ex);
            }
            return returnValue;
        }
    }

    public class PairsComparer : IEqualityComparer<Pairs>
    {

        public bool Equals(Pairs x, Pairs y)
        {
            return x.Dividend == y.Dividend && x.Divider == y.Divider;
        }

        public int GetHashCode(Pairs obj)
        {
            return obj.Dividend.GetHashCode() ^
                obj.Divider.GetHashCode();
        }
    }
}
