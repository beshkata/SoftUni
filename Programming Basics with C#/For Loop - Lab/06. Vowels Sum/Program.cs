﻿using System;

namespace _06._Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case 'a':
                        sum += 1;
                        break;
                    case 'e':
                        sum += 2;
                        break;
                    case 'i':
                        sum += 3;
                        break;
                    case 'o':
                        sum += 4;
                        break;
                    case 'u':
                        sum += 5;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
