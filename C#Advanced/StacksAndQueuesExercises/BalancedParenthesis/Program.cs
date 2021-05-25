using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool isBalanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar == '(' ||
                    currentChar == '[' ||
                    currentChar == '{')
                {
                    stack.Push(currentChar);
                }
                else if (stack.Count > 0)
                {
                    if (currentChar == ')')
                    {
                        if (stack.Peek() != '(')
                        {
                            isBalanced = false;
                            break;
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                    else if (currentChar == '}')
                    {
                        if (stack.Peek() != '{')
                        {
                            isBalanced = false;
                            break;
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                    else if (currentChar == ']')
                    {
                        if (stack.Peek() != '[')
                        {
                            isBalanced = false;
                            break;
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }

                }
                else
                {
                    isBalanced = false;
                    break;
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
