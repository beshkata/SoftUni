﻿
namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age)
            : this()
        {
            this.Age = age;
        }

        public Person(string name, int age)
            : this(age)
        {
            this.Name = name;
        }
        public string Name { get => name; set => name = value; }

        public int Age { get => age; set => age = value; }

        public override string ToString()
        {
            return $"{Name} - {Age}";
        }
    }
}
