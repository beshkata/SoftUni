using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string pizzaName = pizzaInfo[1];
                Pizza pizza = new Pizza(pizzaName);

                string[] doughInfo = Console.ReadLine().Split();

                Dough dough = new Dough(doughInfo[1], doughInfo[2], int.Parse(doughInfo[3]));
                pizza.Dough = dough;

                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }
                    string[] toppingInfo = input.Split();
                    Topping topping = new Topping(toppingInfo[1], int.Parse(toppingInfo[2]));
                    pizza.AddTopping(topping);
                }
                Console.WriteLine(pizza);
            }
            catch (Exception ex) 
            when (ex is ArgumentException || ex is InvalidOperationException)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            
        }
    }
}
