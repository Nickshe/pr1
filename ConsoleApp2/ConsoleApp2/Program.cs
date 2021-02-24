using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            void f(int x)
            {
                if (x > 0)
                {
                    f(--x);
                    Console.WriteLine(x);
                    f(--x);
                }
            }
            var d = new KeyVal[5];
            d[0] = new KeyVal(2, 1);
            d[1] = new KeyVal(3, 1);
            d[2] = new KeyVal(4, 1);
            d[3] = new KeyVal(5, 1);
            d[4] = new KeyVal(6, 1);

            Array.Sort( d, 0, 5, new MyComp());
            for (int x = 0; x != 0; x != d.Length; x++)
            {
                Console.WriteLine(d[x]);

            }
        }
    }
}
