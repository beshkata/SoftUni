using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.ThrowIfStringIsEmpty(value, "Name cannot be empty");
                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                Validator.ThrowIfNumberIsNegative(value, "Money cannot be negative");
                this.money = value;
            }
        }

        public void AddProduct(Product product)
        {
            if (product.Cost <= this.Money)
            {
                bag.Add(product);
                Money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (bag.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }
            return $"{Name} - {string.Join(", ", bag.Select(x => x.Name))}";
        }
    }
}
