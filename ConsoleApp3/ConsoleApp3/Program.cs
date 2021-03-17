using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = new Slist();
            lst.AddLast(1);
            lst.AddLast(2);
            lst.AddFirst(0);

            for(int i=0; i < lst.size; i++)
            {
                Console.Write(lst[i] + " ");
            }
            Console.WriteLine("null");
        }
    }
}
