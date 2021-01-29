using System;
using System.Linq;

namespace CommonElements
{
    class Program
    {
        static void Main()
        {
            string[] firstArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] secondArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] commonElements = new string[Math.Min(firstArr.Length, secondArr.Length)];
            int commonElementIndex = 0;

            for (int i = 0; i < secondArr.Length; i++)
            {
                for (int j = 0; j < firstArr.Length; j++)
                {
                    if (firstArr[j] == secondArr[i])
                    {
                        commonElements[commonElementIndex] = firstArr[j];
                        commonElementIndex++;
                    }
                }
            }
            Console.WriteLine(string.Join(' ', commonElements, 0, commonElements.Count()));
        }
    }
}
