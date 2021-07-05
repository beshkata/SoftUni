using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> peopleByName = new Dictionary<string, Person>();
            Dictionary<string, Product> productsByName = new Dictionary<string, Product>();

            string[] peopleData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            string[] productsData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                peopleByName = FillWithPeopleData(peopleByName, peopleData);
                productsByName = FillWithProductsData(productsByName, productsData);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                string productName = tokens[1];

                peopleByName[personName].AddProduct(productsByName[productName]);
            }

            foreach (var person in peopleByName.Values)
            {
                Console.WriteLine(person.ToString());
            }
        }

        private static Dictionary<string, Product> FillWithProductsData(Dictionary<string, Product> productsByName, string[] productsData)
        {
            foreach (string productData in productsData)
            {
                string[] tokens = productData.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                decimal cost = decimal.Parse(tokens[1]);

                Product product = new Product(name, cost);
                productsByName[name] = product;
            }
            return productsByName;
        }

        private static Dictionary<string, Person> FillWithPeopleData(Dictionary<string, Person> peopleByName, string[] peopleData)
        {
            foreach (string personData in peopleData)
            {
                string[] tokens = personData.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                decimal money = decimal.Parse(tokens[1]);

                Person person = new Person(name, money);
                peopleByName[name] = person;
            }

            return peopleByName;
        }
    }
}
