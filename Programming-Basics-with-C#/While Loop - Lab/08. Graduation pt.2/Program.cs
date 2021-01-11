using System;

namespace _08._Graduation_pt._2
{
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();

            double gradeSum = 0.0; //summing all grades
            int countGrades = 0; // count number of grades 
            int countLowGrades = 0; // count grades below 4.00

            while (countGrades < 12 && countLowGrades < 2)
            {
                double currentGrade = double.Parse(Console.ReadLine());
                if (currentGrade < 4.00)
                {
                    countLowGrades++;
                    if (countLowGrades > 1)
                    {
                        break;
                    }
                }
                gradeSum += currentGrade;
                countGrades++;
            }
            if (countLowGrades > 1)
            {
                Console.WriteLine($"{name} has been excluded at {countGrades} grade");
            }
            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {gradeSum / countGrades:f2}");
            }
        }
    }
}
