using System;
using System.Collections.Generic;
using System.Text;

namespace heshhtable
{
    class hash <TKey, TValue>
    {
        private struct Entry 
        {
            public int hashCode;
            public int next;
            public TKey key;
            public TValue value;
        }
        private int[] buckets;
        private Entry[] entries;
        private int count;
        private int freeList;
        private int freeCount;
        private IEqualityComparer<TKey> comparer;
        public hash (int size)
        {
            //comparer = EqualityComparer<TKey>.Default;
            comparer = (IEqualityComparer<TKey>)(new mycomp());
            buckets = new int[size];
            entries = new Entry[size];
            for (int i = 0; i < size; i++)
            {
                buckets[i] = -1;
            }
            freeList = -1;
        }
        private void Resize()
        {
            Resize(count * 2);
        }
        private void Resize(int newSize)
        {
            int[] newBuckets = new int[newSize];
            for (int i = 0; i < newBuckets.Length; i++)
                newBuckets[i] = -1;
            Entry[] newEntries = new Entry[newSize];
            Array.Copy(entries, 0, newEntries, 0, count);

            for (int i = 0; i < count; i++)
            {
                if (newEntries[i].hashCode >= 0)
                {
                    int bucket = newEntries[i].hashCode % newSize;
                    newEntries[i].next = newBuckets[bucket];
                    newBuckets[bucket] = i;
                }
            }
            buckets = newBuckets;
            entries = newEntries;
        }
        public void Add(TKey key, TValue value)
        {
            int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
            int targetBucket = hashCode % buckets.Length;

            for (int i = buckets[targetBucket]; i >= 0; i = entries[i].next)
            {
                if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key))
                {
                    entries[i].value = value;
                    return;
                }
            }

            int index;
            if (freeCount > 0)
            {
                index = freeList;
                freeList = entries[index].next;
                freeCount--;
            }
            else
            {
                if (count == entries.Length)
                {
                    Resize();
                    targetBucket = hashCode % buckets.Length;
                }
                index = count;
                count++;
            }
            entries[index].hashCode = hashCode;
            entries[index].next = buckets[targetBucket];
            entries[index].key = key;
            entries[index].value = value;
            buckets[targetBucket] = index;
        }

        private int FindEntry(TKey key)
        {
            if (buckets != null)
            {
                int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
                for (int i = buckets[hashCode % buckets.Length]; i >= 0; i = entries[i].next)
                {
                    if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key))
                        return i;
                }
            }
            return -1;
        }
        public TValue this[TKey key]
        {
            get
            {
                int i = FindEntry(key);
                if (i >= 0)
                {
                    return entries[i].value;
                }
                return default(TValue);
            }
            set
            {
                Add(key, value);
            }
        }

        public bool ContainsKey(TKey key)
        {
            return FindEntry(key) >= 0;
        }
        public void Print()
        {
            Console.WriteLine("Index\t Buckets\t\tEntry");
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.Write(i + "\t" + buckets[i]);
                Console.Write("\t\tKey: " + entries[i].key + ", " + entries[i].hashCode);
                Console.WriteLine(entries[i].next <= 0?"": ("->" + entries[i].next));
            }
        }
        public class mycomp: IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return x == y;
            }
            public int GetHashCode(string s)
            {
                int t = 7;
                foreach (var i in s)
                {
                    t *= 31*i;
                }
                return t;
            }
        }
    }
}
