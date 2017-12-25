using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ConcurrentQueue;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void PushPopConcurentTest()
        {
            int n = 10000;
            ConQueue<int> cq = new ConQueue<int>();

            Action push = () =>
            {
                for (int i = 0; i < n; i++)
                {
                    Thread.Sleep(new Random().Next(9));
                    cq.Push(i);
                }
            };

            int totalSum = 0;
            Action pop = () =>
            {
                int localSum = 0;
                for (int i = 0; i < n; i++)
                {
                    Thread.Sleep(new Random().Next(10));
                    localSum += cq.Pop();
                }
                Interlocked.Add(ref totalSum, localSum);
            };

            Parallel.Invoke(push, pop, push, pop);
            Assert.AreEqual(totalSum, Enumerable.Range(0, n).Sum() * 2);
        }
    }
}
