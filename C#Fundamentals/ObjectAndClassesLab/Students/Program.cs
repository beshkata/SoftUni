using System;
using System.Collections.Generic;

namespace Students
{
    class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (input != "end")
            {
                string[] studentInfo = input.Split();
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                int age = int.Parse(studentInfo[2]);
                string homeTown = studentInfo[3];

                Student student = new Student(firstName, lastName, age, homeTown);
                students.Add(student);

                input = Console.ReadLine();
            }

            string sityName = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.HomeTown == sityName)
                {
                    Console.WriteLine(student.ToString());
                }
            }
        }
    }
}
