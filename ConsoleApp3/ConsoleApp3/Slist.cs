using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class Slist
    {
        public Note head;
        public Note tail;
        public int size;

        public Slist()
        {
            head = null;
            tail = head;
            size = 0;
        }

        public void AddLast(int x)
        {
            var n = new Note(x);
            if (head == null)
            {
                head = n;
                tail = head;
            }
            else
            {
                tail.next = n;
                tail = n;
            }
            size++;
        }

        public void AddFirst(int x)
        {
            var n = new Note(x);
            if (head == null)
            {
                head = n;
                tail = head;
            }
            else
            {
                n.next=head;
                head = n;
            }
            size++;
        }

        public int this[int index]
        {
            get
            {
                return getVal(index);
            }
            set
            {
                setVal(index, value);
            }
        }

        private int getVal(int p)
        {
            var curr = head;
            for(int i=0; i<p & curr.next != null;i++)
            {
                curr = curr.next;
            }
            return curr.x;
        }

        private int setVal(int p, int x)
        {
            var curr = head;
            for (int i = 0; i < p & curr.next != null; i++)
            {
                curr = curr.next;
            }
            return curr.x;
        }

        public void insert(int p, int x)
        {
            if (head == null)
            {
                AddLast(x);

            }
            else
            {
                if (p == 0)
                {
                    AddFirst(x);
                }
                else if (p == size)
                {
                    AddLast(x);

                }
                else
                {
                    var curr = head;
                    var prev = head;
                    var n = new Note(x);
                    for(int i=0; i<p & curr != null; i++)
                    {
                        prev = curr;
                        curr = curr.next;
                    }
                    prev.next = n;
                    n.next = curr;
                    size++;
                }
            }
        }

    }
}
