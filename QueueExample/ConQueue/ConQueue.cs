using System.Collections.Generic;
using System.Threading;

namespace ConcurrentQueue
{
    public class ConQueue<T>
    {
        private readonly Queue<T> storage = new Queue<T>();
        private readonly object threadLock = new object();

        public void Push(T item)
        {
            lock (threadLock)
            {
                storage.Enqueue(item);

                // if base storage queue was empty,
                // then pulse all waiting Pop operations
                if (storage.Count == 1)
                {
                    Monitor.PulseAll(threadLock);
                }
            }
        }

        public T Pop()
        {
            lock (threadLock)
            {
                while (storage.Count == 0)
                {
                    Monitor.Wait(threadLock);
                }
                return storage.Dequeue();
            }
        }
    }
}
