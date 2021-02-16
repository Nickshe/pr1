using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Размерность матрицы:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[, ] mass = new int[n,n];
            Random r = new Random();
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int check = 1;
            

            for(int i=0; i < n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    if (check == r.Next(0, 3))
                    {
                        mass[i, j] = 1;
                        
                    }
                    else
                    {
                        mass[i, j] = 0;
                    }
                }
            }
            count(mass);
           
            void print(int[,] mas)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(mass[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            void count(int[,] m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (mass[i, j] == 0)
                        {
                            count1++;
                        }
                        else if (mass[i, j] == 1)
                        {
                            count2++;
                        }
                        else if (mass[i, j] == 2)
                        {
                            count3++;
                        }
                    }

                }
            }
            void fill(int x, int y, int c, int d, int[,] array)
            {
                if (x >= 0 && y >= 0 && x < n && y < n && array[x, y] == d)
                {
                    array[x, y] = c;
                    fill(x + 1, y, c, d, array);
                    fill(x - 1, y, c, d, array);
                    fill(x, y + 1, c, d, array);
                    fill(x, y - 1, c, d, array);

                }

            }

            print(mass);
            

            Console.WriteLine("X: ");
            int x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Y: ");
            int y1 = Convert.ToInt32(Console.ReadLine());


            fill(x1, y1, c:2, d:0, mass);

            print(mass);

           
            count(mass);
            Console.WriteLine("Нолей:"+ count1);
            Console.WriteLine("Единиц:"+count2);
            Console.WriteLine("Двоек:"+count3);

        }
    }
}
