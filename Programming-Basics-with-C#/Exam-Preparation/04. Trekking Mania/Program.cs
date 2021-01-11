using System;

namespace _04._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsNum = int.Parse(Console.ReadLine());

            int totalPeople = 0;

            int musala = 0;
            int monblan = 0;
            int kilimandjaro = 0;
            int k2 = 0;
            int everest = 0;

            for (int i = 0; i < groupsNum; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (input < 6)
                {
                    musala += input;
                }
                else if (input < 13)
                {
                    monblan += input;
                }
                else if (input < 26)
                {
                    kilimandjaro += input;
                }
                else if (input < 41)
                {
                    k2 += input;
                }
                else
                {
                    everest += input;
                }
                totalPeople += input;
            }
            Console.WriteLine($"{1.0 * musala / totalPeople * 100:f2}%");
            Console.WriteLine($"{1.0 * monblan / totalPeople * 100:f2}%");
            Console.WriteLine($"{1.0 * kilimandjaro / totalPeople * 100:f2}%");
            Console.WriteLine($"{1.0 * k2 / totalPeople * 100:f2}%");
            Console.WriteLine($"{1.0 * everest / totalPeople * 100:f2}%");
        }
    }
}
