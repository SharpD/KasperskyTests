using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairFinder
{
    public class PairSum
    {
        private readonly int[] integers;

        public PairSum(IEnumerable<int> intList)
        {
            integers = intList.ToArray();
        }


        public List<Tuple<int, int>> Find(int sum)
        {
            var result = new List<Tuple<int, int>>();
            var uniqInts = new Dictionary<int, int>();
            int diff;

            foreach (int item in integers)
            {
                diff = sum - item;

                SetDefaults(uniqInts, diff, item);

                if (uniqInts[diff] > 0)
                {
                    uniqInts[diff] -= 1;
                    result.Add(Tuple.Create(item, diff));
                }
                else
                {
                    uniqInts[item] += 1;
                }
            }

            return result;
        }

        private static void SetDefaults(Dictionary<int, int> uniqInts, int diff, int item)
        {
            if (!uniqInts.ContainsKey(item))
            {
                uniqInts[item] = 0;
            }

            if (!uniqInts.ContainsKey(diff))
            {
                uniqInts[diff] = 0;
            }

        }


    }
}
