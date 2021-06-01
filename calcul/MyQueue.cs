using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СalcWithStack
{
    class MyQueue<T>
    {
        private T[] items;
        private int count;
        const int n = 10;
        public MyQueue()
        {
            items = new T[n];
        }
        public bool IsEmpty
        {
            get { return count == 0; }
        }
        public int Count
        {
            get { return count; }
        }

        public void Enqueue(T item)
        {
            if (count == items.Length)
                Array.Resize(ref items, items.Length + 1);
            items[count++] = item;
            ////if (count > n)
            //Array.Resize(ref items, count + 10);
            ////count++;
            //items[items.Length] = item;
            //count++;
        }
        public T Dequeue()
        {
            if (!IsEmpty)
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Очередь пуста");
                T item = items[0];
                for (int i = 0; i < count - 1; i++)
                {
                    items[i] = items[i + 1];
                }
                count--;

                items[count] = default(T);
                return item;
            }
            else return default;

        }
        public T Peek()
        {
            if (!IsEmpty)
            {
                return items[0];
            }
            else return default;

        }
        public void Clear()
        {
            Array.Resize(ref items, count - count);
            count = 0;
        }
    }
}
