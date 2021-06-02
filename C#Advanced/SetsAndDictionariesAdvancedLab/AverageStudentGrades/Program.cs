using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> gradesByStudents = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (gradesByStudents.ContainsKey(name) == false)
                {
                    gradesByStudents.Add(name, new List<decimal>());
                }

                gradesByStudents[name].Add(grade);
            }

            foreach (var student in gradesByStudents)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(' ', student.Value.Select(g => g.ToString("f2")))} (avg: {student.Value.Average():f2})");
            }

        }
    }
}
