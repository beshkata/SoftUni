using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int juriNumber = int.Parse(Console.ReadLine());
            string presentationTitle = Console.ReadLine();


            double totalAverage = 0.0;
            int presentationCounter = 0;

            while (presentationTitle != "Finish")
            {
                double averageGrade = 0.0;
                presentationCounter++;
                for (int i = 0; i < juriNumber; i++)
                {
                    averageGrade += double.Parse(Console.ReadLine());
                }
                averageGrade = averageGrade / juriNumber;
                Console.WriteLine($"{presentationTitle} - {averageGrade:f2}.");
                totalAverage += averageGrade;
                presentationTitle = Console.ReadLine();
            }
            totalAverage = totalAverage / presentationCounter;
            Console.WriteLine($"Student's final assessment is {totalAverage:f2}.");
        }
    }
}
