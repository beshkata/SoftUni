using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main()
        {
            List<int> firstList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> secondList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int limit = Math.Min(firstList.Count, secondList.Count);
            List<int> result = new List<int>(firstList.Count + secondList.Count);

            for (int i = 0; i < limit; i++)
            {
                result.Add(firstList[i]);
                result.Add(secondList[i]);
            }

            if (firstList.Count != secondList.Count)
            {
                if (firstList.Count > secondList.Count)
                {
                    result.AddRange(GetRemainingElements(firstList, secondList));
                }
                else
                {
                    result.AddRange(GetRemainingElements(secondList, firstList));
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }

        private static List<int> GetRemainingElements(List<int> longerList, List<int> shorterList)
        {
            List<int> result = new List<int>();
            for (int i = shorterList.Count; i < longerList.Count; i++)
            {
                result.Add(longerList[i]);
            }

            return result;
        }
    }
}
