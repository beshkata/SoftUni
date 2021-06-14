using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people[i] = new Person();
                people[i].Name = personInfo[0];
                people[i].Age = int.Parse(personInfo[1]);                
            }

            string filter = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());

            string formatType = Console.ReadLine();

            Func<Person, bool> condition = GetAgeCondition(filter, filterAge);
            Func<Person, string> formatter = PrintFormatter(formatType);
            PrintPeople(people, condition, formatter);
        }
        static Func<Person, bool> GetAgeCondition(string filter, int filteredAge)
        {
            switch (filter)
            {
                case "older": return p => p.Age >= filteredAge; 
                case "younger": return p => p.Age < filteredAge;
                default:
                    return null;
            }
        }

        static Func<Person, string> PrintFormatter(string formatType)
        {
            if (formatType == "name")
            {
                return p => p.Name;
            }
            else if (formatType == "age")
            {
                return p => p.Age.ToString();
            }
            else
            {
                return p => $"{p.Name} - {p.Age}";
            }
        }

        static void PrintPeople(Person[] people, Func<Person, bool> condition, Func<Person, string> formatter)
        {
            foreach (Person person in people)
            {
                if(condition(person))
                {
                    Console.WriteLine(formatter(person));
                }
            }
        }

    }
}
