using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PairFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int itemCount = 16;
            int minValue = -10;
            int maxValue = 10;

            List<int> integers = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < itemCount; i++)
            {
                integers.Add(rand.Next(minValue, maxValue));
            }

            var p = new PairSum(integers);

            Console.WriteLine("[{0}]\n", String.Join(", ", integers));

            for (int x = -5; x <= 5; x++)
            {
                var result = p.Find(x);

                Console.Write("PairSum = {0,2}: ", x);
                foreach (var tup in result)
                {
                    Console.Write("({0,2}, {1,2}); ", tup.Item1, tup.Item2);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n<Press any key>");
            Console.ReadKey();
        }
    }
}
