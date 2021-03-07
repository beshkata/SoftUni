using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main()
        {
            //You will receive n pair of rows. 
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> gradesToStudents = new Dictionary<string, List<double>>();

            for (int i = 0; i < count; i++)
            {
                //First you will receive the student's name,
                string studentsName = Console.ReadLine();
                //after that you will receive his grade
                double grade = double.Parse(Console.ReadLine());
                //Check if the student already exists and if not, add him. 
                //Keep track of all grades for each student.

                if (gradesToStudents.ContainsKey(studentsName) == false)
                {
                    gradesToStudents.Add(studentsName, new List<double>());
                }
                gradesToStudents[studentsName].Add(grade);
            }
            //When you finish reading the data, 
            //keep the students with average grade higher than or equal to 4.50
            Dictionary<string, double> filteredDic = gradesToStudents
                .Where(x => x.Value.Average() >= 4.5)
                .ToDictionary(x => x.Key, x => x.Value.Average());
            //Order the filtered students by average grade in descending order.
            filteredDic = filteredDic
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
            //Print the students and their average grade in the following format:
            //{ name} –> { averageGrade}
            //Format the average grade to the 2nd decimal place.
            foreach (var kvp in filteredDic)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:f2}");
            }
        }
    }
}
