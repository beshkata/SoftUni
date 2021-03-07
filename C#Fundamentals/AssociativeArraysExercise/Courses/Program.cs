using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main()
        {
            //Until the "end" command is received, you will be receiving input in the format: 
            //"{courseName} : {studentName}"
            //The product data is always delimited by " : ".
            Dictionary<string, List<string>> studentsToCourses = new Dictionary<string, List<string>>();
            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] info = line.Split(" : ");
                string courseName = info[0];
                string studentName = info[1];
                //Check if such course already exists, and if not, add the course.
                if (studentsToCourses.ContainsKey(courseName) == false)
                {
                    studentsToCourses.Add(courseName, new List<string>());
                }
                studentsToCourses[courseName].Add(studentName);

                line = Console.ReadLine();
            }
            //print the courses with their names and total registered users,
            //ordered by the count of registered users in descending order. 
            Dictionary<string, List<string>> orderedDic = new Dictionary<string, List<string>>();
            orderedDic = studentsToCourses
                .OrderByDescending(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var kvp in orderedDic)
            {
                //Print the information about each course in the following the format: 
                //"{courseName}: {registeredStudents}"
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                //For each contest print the registered users ordered by name in ascending order.
                kvp.Value.Sort();
                //Print the information about each student, in the following the format:
                //"-- {studentName}"
                foreach (string studentName in kvp.Value)
                {
                    Console.WriteLine($"-- {studentName}");
                }
            }
        }
    }
}
