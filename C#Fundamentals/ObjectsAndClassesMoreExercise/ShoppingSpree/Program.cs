using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Person
    {
        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }
        public string Name { get; set; }

        public double Money { get; set; }

        public List<Product> Products { get; set; }

        public void Buy(Product product)
        {
            if (product.Price > Money)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            else
            {
                Products.Add(product);
                Money -= product.Price;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
        }

        public override string ToString()
        {
            if (Products.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{Name} - ");

            for (int i = 0; i < Products.Count; i++)
            {
                if (i < Products.Count - 1)
                {
                    stringBuilder.Append(Products[i].Name + ", ");
                }
                else
                {
                    stringBuilder.Append(Products[i].Name);
                }
            }
            return stringBuilder.ToString();
        }
    }
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            string[] personsInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < personsInfo.Length; i++)
            {
                string[] currentPerson = personsInfo[i].Split('=');
                string name = currentPerson[0];
                double money = double.Parse(currentPerson[1]);

                Person person = new Person(name, money);
                people.Add(person);
            }

            List<Product> products = new List<Product>();
            string[] productsInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productsInfo.Length; i++)
            {
                string[] currentProduct = productsInfo[i].Split('=');

                string name = currentProduct[0];
                double price = double.Parse(currentProduct[1]);

                Product product = new Product(name, price);
                products.Add(product);
            }

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] input = line.Split();
                string personName = input[0];
                string productName = input[1];
                int personIndex = GetPersonIndex(people, personName);
                int productIndex = GetProductIndex(products, productName);

                people[personIndex].Buy(products[productIndex]);

                line = Console.ReadLine();
            }

            foreach (Person person1 in people)
            {
                Console.WriteLine(person1);
            }
        }

        private static int GetProductIndex(List<Product> products, string productName)
        {
            int index = -1;

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name == productName)
                {
                    index = i;
                    return index;
                }
            }

            return index;
        }

        private static int GetPersonIndex(List<Person> people, string personName)
        {
            int index = -1;

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Name == personName)
                {
                    index = i;
                    return index;
                }
            }

            return index;
        }
    }
}
