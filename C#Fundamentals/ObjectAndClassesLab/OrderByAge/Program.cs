using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
    class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] personInfo = line.Split();
                string name = personInfo[0];
                string id = personInfo[1];
                int age = int.Parse(personInfo[2]);

                Person person = new Person(name, id, age);
                people.Add(person);
                line = Console.ReadLine();
            }

            people = people.OrderBy(a => a.Age).ToList();

            foreach (Person person1 in people)
            {
                Console.WriteLine(person1.ToString());
            }
        }
    }
}
