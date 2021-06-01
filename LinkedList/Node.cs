using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Node<T>
    {
        public T x;
        public Node<T> next;
        public Node<T> prev;
        public Node(T date)
        {
            x = date;
            next = null;
        }
        public T Value
        {
            get { return x; }
            set { x = value; }
        }
    }
}