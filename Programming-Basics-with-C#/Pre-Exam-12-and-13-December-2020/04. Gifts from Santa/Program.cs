using System;

namespace _04._Gifts_from_Santa
{
    class Program
    {
        static void Main(string[] args)
        {
            int finalNum = int.Parse(Console.ReadLine());
            int startNum = int.Parse(Console.ReadLine());
            int without = int.Parse(Console.ReadLine());

            for (int i = startNum; i >= finalNum; i--)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    if (i != without)
                    {
                        Console.Write(i + " ");
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }
    }
}
