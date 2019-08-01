using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{

    public class Pares
    {
        public int Dividendo { get; set; }
        public int Divisor { get; set; }

        // Um array de inteiros devolva todos os pares em que um dos números é divisível pelo outro. 
        public static Pares[] ParesDivisiveis(int[] arrayInt, bool removerDuplicacoes = false)
        {
            int p = 0;
            var itens01 = arrayInt.ToDictionary(x => p++, x => x);

            List<Pares> retorno = new List<Pares>();

            itens01.ToList().ForEach(item =>
                                        retorno.AddRange(itens01.Where(x => item.Key != x.Key && (item.Value % x.Value) == 0)
                                                                .Select(y => new Pares { Dividendo = item.Value, Divisor = y.Value })
                                                                .ToArray())
                                    );

            if (removerDuplicacoes)
                retorno = retorno.Distinct(new ParesComparer()).ToList();

            return retorno.ToArray();
        }
    }

    public class ParesComparer : IEqualityComparer<Pares>
    {

        public bool Equals(Pares x, Pares y)
        {
            return x.Dividendo == y.Dividendo && x.Divisor == y.Divisor;
        }

        public int GetHashCode(Pares obj)
        {
            return obj.Dividendo.GetHashCode() ^
                obj.Divisor.GetHashCode();
        }
    }
}
