using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100;

            ConQueue<int> cq = new ConQueue<int>();

            Action push = () =>
                {
                    for (int i = 0; i < n; i++)
                    {
                        Thread.Sleep(new Random().Next(9));
                        cq.Push(i);
               
                        Console.WriteLine("<= {0}", i);
                    }
                };

            int totalSum = 0;
            Action pop = () =>
                {
                    int localSum = 0;
                    for (int i = 0; i < n; i++)
                    {
                        Thread.Sleep(new Random().Next(10));
                        int x = cq.Pop();
                        
                        Console.WriteLine("-> {0}", x);
                    }
                    Interlocked.Add(ref totalSum, localSum);
                };
            
            // Start concurrent actions
            Parallel.Invoke(push, pop);

            Console.WriteLine("\n<Press a key>");
            Console.ReadKey();
        }
    }
}
