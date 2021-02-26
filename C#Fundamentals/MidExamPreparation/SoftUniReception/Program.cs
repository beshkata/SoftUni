using System;

namespace SoftUniReception
{
    class Program
    {
        static void Main()
        {
            int totalEmpoyeesCapacity = 0;

            for (int i = 0; i < 3; i++)
            {
                totalEmpoyeesCapacity += int.Parse(Console.ReadLine());
            }

            int totalStudents = int.Parse(Console.ReadLine());

            double time = Math.Ceiling(1.0 * totalStudents / totalEmpoyeesCapacity);

            int totalTime = (int)(time + time / 3);

            if (time % 3 == 0 && totalStudents != 0)
            {
                totalTime -= 1;
            }

            Console.WriteLine($"Time needed: {totalTime}h.");
        }
    }
}
