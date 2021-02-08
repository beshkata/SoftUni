using System;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main()
        {
            string valueType = Console.ReadLine();
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            string result = String.Empty;

            switch (valueType)
            {
                case "int":
                    int firstInt = int.Parse(first);
                    int secondInt = int.Parse(second);
                    result = GetMaxValue(firstInt, secondInt);
                    break;
                case "char":
                    char firstChar = char.Parse(first);
                    char secondChar = char.Parse(second);
                    result = GetMaxValue(firstChar, secondChar);
                    break;
                case "string":
                    result = GetMaxValue(first, second);
                    break;
                default:
                    Console.WriteLine("Wrong value type");
                    break;
            }
            Console.WriteLine(result);
        }

        private static string GetMaxValue(string first, string second)
        {
            int end = Math.Min(first.Length, second.Length);
            for (int i = 0; i < end; i++)
            {
                if (first[i] > second[i])
                {
                    return first;
                }
                else if (second[i] > first[i])
                {
                    return second;
                }
            }

            if (first.Length > second.Length)
            {
                return first;
            }
            else
            {
                return second;
            }

        }

        private static string GetMaxValue(int firstValue, int secondValue)
        {
            return Math.Max(firstValue, secondValue).ToString();
        }

        private static string GetMaxValue(char firstValue, char secondValue)
        {
            char result = (char)Math.Max(firstValue, secondValue);
            return result.ToString();
        }

    }
}
