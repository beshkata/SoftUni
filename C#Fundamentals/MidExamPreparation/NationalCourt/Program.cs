using System;

namespace NationalCourt
{
    class Program
    {
        static void Main()
        {
            int employeesEfficiency = 0;

            for (int i = 0; i < 3; i++)
            {
                employeesEfficiency += int.Parse(Console.ReadLine());
            }

            int peopleCount = int.Parse(Console.ReadLine());

            int totalTime = 0;
            int workingHours = 0;

            while (peopleCount > 0)
            {
                peopleCount -= employeesEfficiency;
                totalTime++;
                workingHours++;

                if (workingHours == 3 && peopleCount > 0)
                {
                    totalTime++;
                    workingHours = 0;
                }
            }


            Console.WriteLine($"Time needed: {totalTime}h.");
        }
    }
}
