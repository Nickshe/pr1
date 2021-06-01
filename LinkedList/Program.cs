using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = new SLList<int>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                lst.AddLast(rand.Next(1, 100));
                Console.Write(lst[i] + " ");
            }
            lst.AddFirst(0);
            lst.AddLast(0);
            lst.Insert(5, 0);
            Console.WriteLine();
            foreach (var v in lst)
            {
                Console.Write(v + " ");
            }
            lst.Remove(-2);
            lst.Remove(100);
            Console.WriteLine();
            foreach (var v in lst)
            {
                Console.Write(v + " ");
            }
        }
    }
}