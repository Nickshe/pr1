using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
   public class MyStack<T>
    {
        private T[] items;
        private int count;
        const int n = 10;
        public MyStack()
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
        public void Push(T item)
        {
            if (count == items.Length)
                Array.Resize(ref items, items.Length + 1);
            items[count++] = item;
        }
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            T item = items[--count];
            items[count] = default(T);
            return item;
        }
        public T Peek()
        {
            return items[count - 1];
        }
    }
}
