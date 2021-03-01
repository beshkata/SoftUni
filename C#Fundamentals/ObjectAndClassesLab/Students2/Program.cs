using System;
using System.Collections.Generic;

namespace Students2
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

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            if (firstStudent.FirstName == secondStudent.FirstName &&
                firstStudent.LastName == secondStudent.LastName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !(firstStudent == secondStudent);
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
                if (OverrideStudentIfExist(students, student) == false)
                {
                    students.Add(student);
                }

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

        private static bool OverrideStudentIfExist(List<Student> students, Student student)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i] == student)
                {
                    students[i].Age = student.Age;
                    students[i].HomeTown = student.HomeTown;
                    return true;
                }
            }
            return false;
        }
    }
}
