using System;
using System.Collections.Generic;
using System.Linq;

namespace Softuniada2022
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int biggerNum;
            int smallerNum;

            if (n > m)
            {
                biggerNum = n;
                smallerNum = m;
            }
            else
            {
                biggerNum = m;
                smallerNum = n;
            }

            int GCD = FindGreatestCommonDivisor(smallerNum, biggerNum);
            int LCM = FindLeastCommonMultiple(smallerNum, biggerNum);

            Console.WriteLine(GCD + LCM);
        }

        private static int FindLeastCommonMultiple(int smallerNum, int biggerNum)
        {
            List<int> smallerNumMultiple = new List<int>();
            List<int> biggerNumMultiple = new List<int>();

            smallerNumMultiple = FindMultipiers(smallerNum);
            biggerNumMultiple = FindMultipiers(biggerNum);

            int LCM = FindLeastCommonMultiple(smallerNumMultiple, biggerNumMultiple);
            return LCM;
        }

        private static int FindLeastCommonMultiple(List<int> smallerNumMultiple, List<int> biggerNumMultiple)
        {
            List<int> resultList = new List<int>();

            for (int i = 0; i < Math.Min(smallerNumMultiple.Count, biggerNumMultiple.Count); i++)
            {
                if (smallerNumMultiple.Contains(biggerNumMultiple[i]))
                {
                    resultList.Add(biggerNumMultiple[i]);
                }
            }

            for (int i = 0; i < resultList.Count; i++)
            {
                smallerNumMultiple.Remove(resultList[i]);
                biggerNumMultiple.Remove(resultList[i]);
            }
            resultList.AddRange(smallerNumMultiple);
            resultList.AddRange(biggerNumMultiple);

            int result = 1;
            foreach (var num in resultList)
            {
                result *= num;
            }
            return result;
        }

        private static List<int> FindMultipiers(int number)
        {
            List<int> result = new List<int>();
            while (number != 1)
            {
                for (int i = 2; i < 10; i++)
                {
                    if (number % i == 0)
                    {
                        result.Add(i);
                        number /= i;
                        break;
                    }
                }
            }

            return result;
        }

        private static int FindGreatestCommonDivisor(int smallerNum, int biggerNum)
        {
            int temp = 1;
            while (true)
            {
                temp = biggerNum % smallerNum;
                biggerNum = smallerNum;
                if (temp == 0)
                {
                    break;
                }
                smallerNum = temp;

            }

            return smallerNum;
        }
    }
}
