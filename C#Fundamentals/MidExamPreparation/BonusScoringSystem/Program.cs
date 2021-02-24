using System;

namespace BonusScoringSystem
{
    class Program
    {
        static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int initialBonus = int.Parse(Console.ReadLine());

            int[] attendances = new int[studentsCount];

            for (int i = 0; i < studentsCount; i++)
            {
                attendances[i] = int.Parse(Console.ReadLine());
            }

            double[] totalBonuses = new double[studentsCount];

            for (int i = 0; i < studentsCount; i++)
            {
                totalBonuses[i] = Math.Ceiling(1.0* attendances[i] / lecturesCount * (5 + initialBonus)) ;
            }

            int maxBonus = 0;
            int lecturesAttendanceMaxBonus = 0;

            for (int i = 0; i < totalBonuses.Length; i++)
            {
                if (totalBonuses[i] >= maxBonus)
                {
                    maxBonus = (int)totalBonuses[i];
                    lecturesAttendanceMaxBonus = attendances[i];
                }
            }

            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {lecturesAttendanceMaxBonus} lectures.");
        }
    }
}
