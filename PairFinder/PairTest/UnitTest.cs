using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

using PairFinder;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void FindPairsTest()
        {
            int itemCount = 10000;
            int minValue = -1000;
            int maxValue = 1000;

            List<int> integers = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < itemCount; i++)
            {
                integers.Add(rand.Next(minValue, maxValue));
            }

            var p = new PairSum(integers);

            for (int x = -10; x < 11; x++)
            {
                var result = p.Find(x);

                List<int> intCheck = integers.ToList();
                foreach (var tup in result)
                {
                    Assert.AreEqual(tup.Item1 + tup.Item2, x);

                    intCheck.Remove(tup.Item1);
                    intCheck.Remove(tup.Item2);
                }
                Assert.IsTrue(intCheck.Count == itemCount - result.Count * 2);
                
            }
        }
    }
}

