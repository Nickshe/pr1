using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    class Program
    {
        public static int width;
        public static int height;
        public static int[,] matrix;
        public static MyStack<KeyValuePair<int, int>> stack = new MyStack<KeyValuePair<int, int>>();
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ширину матрицы");
            width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите высоту матрицы");
            height = Convert.ToInt32(Console.ReadLine());
            matrix = new int[width, height];
            Random rand = new Random();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (rand.Next(1, 4) == 1)
                    {
                        matrix[i, j] = 1;
                    }
                    else matrix[i, j] = 0;
                }
            }
            DrawMatrix();
            Console.WriteLine("Введите координату X точки начала");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату Y точки начала");
            int y = Convert.ToInt32(Console.ReadLine());
            var coordinates = new KeyValuePair<int, int>(x, y);

            if (matrix[x, y] == 0)
            {
                Fill(coordinates);
            }
            DrawMatrix();
        }
        static void DrawMatrix()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(matrix[j, i]);
                }
                Console.WriteLine();
            }
            Count();
        }
        static void Fill(KeyValuePair<int, int> coordinates)
        {
            stack.Push(coordinates);
            while (!stack.IsEmpty)
            {
                var t = stack.Peek();
                stack.Pop();
                matrix[t.Key, t.Value] = 2;
                if (t.Key + 1 < width && matrix[t.Key + 1, t.Value] == 0)
                {
                    coordinates = new KeyValuePair<int, int>(t.Key + 1, t.Value);
                    stack.Push(coordinates);
                }
                if (t.Value - 1 >= 0 && matrix[t.Key, t.Value - 1] == 0)
                {
                    coordinates = new KeyValuePair<int, int>(t.Key, t.Value - 1);
                    stack.Push(coordinates);
                }
                if (t.Key - 1 >= 0 && matrix[t.Key - 1, t.Value] == 0)
                {
                    coordinates = new KeyValuePair<int, int>(t.Key - 1, t.Value);
                    stack.Push(coordinates);
                }
                if (t.Value + 1 < height && matrix[t.Key, t.Value + 1] == 0)
                {
                    coordinates = new KeyValuePair<int, int>(t.Key, t.Value + 1);
                    stack.Push(coordinates);
                }
            }
        }
        static void Count()
        {
            int count0 = 0, count1 = 0, count2 = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (matrix[i, j] == 0) count0++;
                    else if (matrix[i, j] == 1) count1++;
                    else if (matrix[i, j] == 2) count2++;
                }
            }
            Console.WriteLine("Нулей: " + count0 + " Единиц: " + count1 + " Двоек: " + count2);
        }
    }
}
