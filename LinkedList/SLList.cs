using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LinkedList
{
    class SLList<T> : IEnumerable
    {
        public Node<T> head;
        public Node<T> tail;
        public int size;
        public SLList()
        {
            head = null;
            tail = head;
            size = 0;
        }
        public IEnumerator GetEnumerator()
        {
            var tmp = head;
            for (int i = 0; i < size; i++)
            {
                yield return tmp.Value;
                tmp = tmp.next;
            }
        }
        //public IEnumerator GetEnumerator()
        //{
        //    var tmp = tail;
        //    for (int i = size; i > 0; i--)
        //    {
        //        yield return tmp.Value;
        //        tmp = tmp.prev;
        //    }
        //}
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public void AddLast(T x)
        {
            var n = new Node<T>(x);
            if (head == null)
            {
                head = n;
                tail = head;
            }
            else
            {
                n.prev = tail;
                tail.next = n;
                tail = n;

            }
            ++size;
        }
        public void AddFirst(T x)
        {
            var n = new Node<T>(x);
            var tmp = new Node<T>(x);
            if (head == null)
            {
                head = n;
                tail = head;
            }
            else
            {
                tmp = head;
                head = n;
                head.next = tmp;
            }
            ++size;
        }
        public T this[int index]
        {
            get { return GetVal(index); }
            set { SetVal(index, value); }
        }
        private T GetVal(int index)
        {
            var curr = head;
            if (index < size / 2)
            {
                curr = head;
                for (int i = 0; i < index && curr.next != null; i++)
                {
                    curr = curr.next;
                }
                return curr.x;
            }
            else
            {
                curr = tail;
                for (int i = size; i > index + 1 && curr.prev != null; i--)
                {
                    curr = curr.prev;
                }
                return curr.x;
            }
        }
        private void SetVal(int index, T x)
        {
            var curr = head;
            if (index < size / 2)
            {
                curr = head;
                for (int i = 0; i < index && curr.next != null; i++)
                {
                    curr = curr.next;
                }
                curr.x = x;
            }
            else
            {
                curr = tail;
                for (int i = size; i > index + 1 && curr.prev != null; i--)
                {
                    curr = curr.prev;
                }
                curr.x = x;
            }
        }
        public void Insert(int index, T item)
        {
            Node<T> node = new Node<T>(item);
            Node<T> tmp = head;
            if (index == 0 || size == 0)
            {
                AddFirst(item);
            }
            else if (index >= size)
            {
                AddLast(item);
            }
            else if (index < size / 2)
            {
                ++size;
                tmp = head;
                for (int i = 0; i < index - 1; i++)
                {
                    tmp = tmp.next;
                }
                tmp.next.prev = node;
                node.next = tmp.next;
                tmp.next = node;
                node.prev = tmp;
            }
            else
            {
                tmp = tail;
                for (int i = size - 1; i > index; i--)
                {
                    tmp = tmp.prev;
                }
                tmp.prev.next = node;
                node.prev = tmp.prev;
                tmp.prev = node;
                node.next = tmp;
                ++size;
            }
        }
        public void Remove(int index)
        {
            if (index >= size)
            {
                Remove(size - 1);
            }
            else if (index < 0)
            {
                Remove(0);
            }
            else
            {
                var tmp = head;
                if (index == 0)
                {
                    head = head.next;
                }
                if (index < size / 2)
                {
                    for (int i = 0; i < index - 1; i++)
                    {
                        tmp = tmp.next;
                    }
                }
                else
                {
                    tmp = tail;
                    for (int i = size - 1; i >= index; i--)
                    {
                        tmp = tmp.prev;
                    }
                }
                if (index == size - 1)
                {
                    tail = tmp;
                    tmp.next = tmp.next.next;
                }
                else
                {
                    tmp.next = tmp.next.next;
                    tmp.next.prev = tmp;
                }
                --size;
            }
        }
        public T First
        {
            get { return head.Value; }
            set { head.Value = value; }
        }
        public T Last
        {
            get { return tail.Value; }
            set { tail.Value = value; }
        }
        public void Clear()
        {
            head = null;
            tail = null;
            size = 0;
        }
        public int indexOf(T item)
        {
            var tmp = head;
            for (int i = 0; i < size - 1; i++)
            {

                if (tmp.Value.Equals(item))
                {
                    return i;
                }
                tmp = tmp.next;
            }
            return -1;
        }
    }
}
