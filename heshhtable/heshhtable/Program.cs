using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace heshhtable
{
    class Program
    {
        static void Main(string[] args)
        {
            //var init = new string[]{"Artyom1", "Vanya", "Seva","Nikita", "Liza", "Bair", "Emil"};
            //var h = new hash<string, int>(7);
            //foreach(var i in init)
            //{
            //    h.Add(i, 1);
            //}
            //h.Print();
            string text = System.IO.File.ReadAllText(@"big.txt");
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            long elapsedMs;
            Console.WriteLine(text.Length);
            var cont = new hash<string, int>(7);
            var str = new StringBuilder();
            foreach (var i in text)
            {
                if ((i >= 'a' && i <= 'z') || (i >= 'A' && i <= 'Z'))
                {
                    str.Append(i);
                }
                else if (str.Length > 0)
                {
                    var s = str.ToString();
                    if (cont.ContainsKey(s))
                        ++cont[s];
                    else
                        cont.Add(s, 1);
                    //try
                    //{
                    //    ++cont[s];
                    //}
                    //catch (KeyNotFoundException)
                    //{
                    //    cont.Add(s, 1);
                    //}
                    str.Clear();
                }
            }
            Console.WriteLine(cont["the"]);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine("time:  " + elapsedMs);
            Console.WriteLine();
            //cont.Print();
        }
    }
}
