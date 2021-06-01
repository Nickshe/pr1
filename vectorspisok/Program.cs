using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_2
{
    class Program
    {
        public static MyList<int> VectorList = new MyList<int>();
        static void Main(string[] args)
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                VectorList.Add(rand.Next(1, 100));
                Console.Write(VectorList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Insert(Добавляем нолики в начало, в конец и в середину)");
            VectorList.Insert(0, 0);
            VectorList.Insert(5, 0);
            VectorList.Insert(VectorList.Size, 0);
            foreach (var v in VectorList)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();
            Console.WriteLine("RemoveAt(Удаляем наши нолики)");
            VectorList.RemoveAt(0);
            VectorList.RemoveAt(4);
            VectorList.RemoveAt(VectorList.Size);
            foreach (var v in VectorList)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Contains");
            Console.WriteLine(VectorList.Contains(VectorList[0]));
            Console.WriteLine(VectorList.Contains(1000));
            Console.WriteLine("First");
            Console.WriteLine(VectorList.First);
            Console.WriteLine("Last");
            Console.WriteLine(VectorList.Last);
            Console.WriteLine("Find(Число кратное трём)");
            Console.WriteLine(VectorList.Find(x => { return x % 3 == 0; }));
            Console.WriteLine("FindIndex(Индекс этого числа)");
            Console.WriteLine(VectorList.FindIndex(x => { return x % 3 == 0; }));
            Console.WriteLine("ForEach");
            VectorList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine("Clear");
            VectorList.Clear();
            foreach (var v in VectorList)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();
        }
    }
}
