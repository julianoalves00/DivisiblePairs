using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class Player
    {
        public static void ShotFire(string[] args)
        {

            // game loop
            Dictionary<int, int> moutains = new Dictionary<int, int>();
            for (int i = 0; i < 8; i++)
            {
                moutains.Add(i, int.Parse(Console.ReadLine())); // represents the height of one mountain.
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            // The index of the mountain to fire on.
            //Console.WriteLine(moutains.FirstOrDefault());
            Console.WriteLine(moutains.OrderByDescending(y => y.Value)
                            .FirstOrDefault().Key);


        }
    }
}
