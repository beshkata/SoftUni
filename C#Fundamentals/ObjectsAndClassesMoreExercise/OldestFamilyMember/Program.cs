using System;
using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember
{
    class Person
    {
        public Person()
        {

        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

    class Family
    {
        public Family()
        {
            FamilyMembers = new List<Person>();
        }
        public List<Person> FamilyMembers { get; set; }

        public void AddMember(Person member)
        {
            FamilyMembers.Add(member);
        }

        public Person GetOldestPerson()
        {
            return FamilyMembers.OrderByDescending(a => a.Age).First();
        }
    }
    class Program
    {
        static void Main()
        {
            int membersCount = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < membersCount; i++)
            {
                string[] memberInfo = Console.ReadLine().Split();
                string name = memberInfo[0];
                int age = int.Parse(memberInfo[1]);

                family.AddMember(new Person(name, age));
            }

            Console.WriteLine(family.GetOldestPerson());
        }
    }
}
