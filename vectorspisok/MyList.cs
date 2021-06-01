using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_2
{
    class MyList<T> : IEnumerable
    {
        static int size = 0;
        static T[] array = new T[size];
        static int cop = 1;

        public IEnumerator GetEnumerator()
        {
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                    yield return array[i];
            }
        }

        public void Add(T item)
        {
            size += 1;
            if (size < cop)
            {
                array[size - 1] = item;
            }
            else
            {
                cop = cop * 2;
                Array.Resize<T>(ref array, cop);
                array[size - 1] = item;
            }
        }

        public void Insert(int index, T item)
        {
            if (index >= size)
            {
                Add(item);
            }
            else
            {
                T temp = array[0];
                if (size >= cop)
                {
                    cop = cop * 2;
                    Array.Resize<T>(ref array, cop);
                }
                size += 1;
                array[size] = array[0];
                for (int i = index; i < size; i++)
                {
                    temp = array[i + 1];
                    array[i + 1] = array[index];
                    array[index] = temp;
                }
                array[index] = item;
            }
        }

        public void RemoveAt(int index)
        {
            T temp = array[0];
            for (int i = size; i > index; i--)
            {
                temp = array[i - 1];
                array[i - 1] = array[index];
                array[index] = temp;
            }
            size--;
        }

        public T Last
        {
            get { return array[size - 1]; }
            set { array[size - 1] = value; }

        }

        public T First
        {
            get { return array[0]; }
            set { array[0] = value; }
        }

        public void Clear()
        {
            Array.Resize<T>(ref array, 0);
            size = 0;
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public bool Contains(T item)
        {
            foreach (var i in array)
            {
                if (item.Equals(i))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < size; i++)
            {
                action(array[i]);
            }
        }

        public T Find(Predicate<T> match)
        {
            for (int i = 0; i < size; i++)
            {
                if (match(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);
        }

        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < size; i++)
            {
                if (match(array[i]))
                {
                    return i;
                }
            }
            return -1;
        }
        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

    }
}

