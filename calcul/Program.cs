using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СalcWithStack
{
    class Program
    {
        public static MyQueue<string> queue = new MyQueue<string>();
        public static MyStack<string> stack = new MyStack<string>();
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            toRPN(line);
            Counting();
        }
        static private byte GetPriority(char c)
        {
            switch (c)
            {
                case '(': return 0;
                case ')': return 0;
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                default: return 6;
            }
        }
        static public bool isOperator(string c)
        {
            if ((c == "(" || c == ")" || c == "+" || c == "-" || c == "*" || c == "/"))
            {
                return true;
            }
            else return false;
        }
        static public void toRPN(string line)
        {
            bool isNumber;
            string number = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (isOperator(Convert.ToString(line[i])))
                {
                    if (line[i] == ')')
                    {
                        while (stack.Peek() != "(")
                        {
                            queue.Enqueue(Convert.ToString(stack.Pop()));
                        }
                        stack.Pop();
                    }
                    else
                    {
                        if (!stack.IsEmpty)
                        {
                            if (GetPriority(line[i]) != 0)
                            {
                                if (GetPriority(line[i]) > GetPriority(Convert.ToChar(stack.Peek())))
                                {
                                    stack.Push(Convert.ToString(line[i]));
                                }
                                else
                                {
                                    queue.Enqueue(Convert.ToString(stack.Pop()));
                                    stack.Push(Convert.ToString(line[i]));
                                }
                            }
                            else
                            {
                                stack.Push(Convert.ToString(line[i]));
                            }
                        }
                        else
                        {
                            stack.Push(Convert.ToString(line[i]));
                        }
                    }
                }
                else
                {
                    isNumber = true;
                    for (int j = i; isNumber && j < line.Length; j++)
                    {
                        if (!isOperator(Convert.ToString(line[j])))
                        {
                            number += Convert.ToString(line[j]);
                        }
                        else
                        {
                            isNumber = false;
                            i = j - 1;
                        }
                    }
                    queue.Enqueue(number);
                    number = "";
                }
            }
            while (stack.Count != 0)
            {
                queue.Enqueue(Convert.ToString(stack.Pop()));
            }
        }
        static public void Counting()
        {
            int a = 0, b = 0;
            while (!queue.IsEmpty)
            {
                if (!isOperator(queue.Peek()))
                {
                    stack.Push(queue.Dequeue());
                }
                else
                {
                    if (queue.Peek() == "+")
                    {
                        queue.Dequeue();
                        b = Convert.ToInt32(stack.Pop());
                        a = Convert.ToInt32(stack.Pop());
                        stack.Push(Convert.ToString(a + b));
                    }
                    else if (queue.Peek() == "-")
                    {
                        queue.Dequeue();
                        b = Convert.ToInt32(stack.Pop());
                        a = Convert.ToInt32(stack.Pop());
                        stack.Push(Convert.ToString(a - b));
                    }
                    else if (queue.Peek() == "/")
                    {
                        queue.Dequeue();
                        b = Convert.ToInt32(stack.Pop());
                        a = Convert.ToInt32(stack.Pop());
                        stack.Push(Convert.ToString(a / b));
                    }
                    else if (queue.Peek() == "*")
                    {
                        queue.Dequeue();
                        b = Convert.ToInt32(stack.Pop());
                        a = Convert.ToInt32(stack.Pop());
                        stack.Push(Convert.ToString(a * b));
                    }
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
