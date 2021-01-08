using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main()
        {
            int numberBadGrades = int.Parse(Console.ReadLine());
            int badGradesCounter = 0;
            int sumGrades = 0;
            int gradeCounter = 0;

            string taskName = Console.ReadLine();
            int grade = int.Parse(Console.ReadLine());

            while (taskName != "Enough")
            {
                if (grade <= 4)
                {
                    badGradesCounter++;
                    if (badGradesCounter == numberBadGrades)
                    {
                        Console.WriteLine($"You need a break, {badGradesCounter} poor grades.");
                        break;
                    }
                }
                gradeCounter++;
                sumGrades += grade;
                string str = Console.ReadLine();
                if (str == "Enough")
                {
                    break;
                }
                taskName = str;
                grade = int.Parse(Console.ReadLine());
            }
            if (badGradesCounter != numberBadGrades)
            {
                Console.WriteLine($"Average score: {(double)sumGrades / gradeCounter:f2}");
                Console.WriteLine($"Number of problems: {gradeCounter}");
                Console.WriteLine($"Last problem: {taskName}");
            }
        }
    }
}
