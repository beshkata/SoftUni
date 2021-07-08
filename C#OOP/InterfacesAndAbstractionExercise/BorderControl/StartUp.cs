using BorderControl.Contracts;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //BorderControl
            //List<IIdentifiable> identifiables = new List<IIdentifiable>();

            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    if (input == "End")
            //    {
            //        break;
            //    }

            //    string[] tokens = input.Split();

            //    if (tokens.Length == 2)
            //    {
            //        string model = tokens[0];
            //        string id = tokens[1];
            //        IIdentifiable robot = new Robot(model, id);
            //        identifiables.Add(robot);
            //    }
            //    else
            //    {
            //        string name = tokens[0];
            //        int age = int.Parse(tokens[1]);
            //        string id = tokens[2];
            //        IIdentifiable citizen = new Citizen(name, age, id);
            //        identifiables.Add(citizen);
            //    }
            //}

            //string fakeId = Console.ReadLine();

            //foreach (IIdentifiable identifiable in identifiables)
            //{
            //    if(identifiable.Id.EndsWith(fakeId))
            //    {
            //        Console.WriteLine(identifiable.Id);
            //    }
            //}

            //BirthdayCelebrations
            //List<IBirthable> birthables = new List<IBirthable>();

            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    if (input == "End")
            //    {
            //        break;
            //    }

            //    string[] tokens = input.Split();
            //    string command = tokens[0];
            //    string name = tokens[1];

            //    if (command == "Pet")
            //    {
            //        string birthdate = tokens[2];
            //        IBirthable pet = new Pet(name, birthdate);
            //        birthables.Add(pet);
            //    }
            //    else if (command == "Citizen")
            //    {
            //        int age = int.Parse(tokens[2]);
            //        string id = tokens[3];
            //        string birthdate = tokens[4];

            //        IBirthable citizen = new Citizen(name, age, id, birthdate);
            //        birthables.Add(citizen);
            //    }

            //}

            //string year = Console.ReadLine();

            //foreach (var birthable in birthables)
            //{
            //    if (birthable.Birthdate.EndsWith(year))
            //    {
            //        Console.WriteLine(birthable.Birthdate);
            //    }
            //}

            //Food Shortage
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                if (tokens.Length == 4)
                {
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    IBuyer citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(name, citizen);
                }
                else
                {
                    string group = tokens[2];

                    IBuyer rebel = new Rebel(name, age, group);
                    buyers.Add(name, rebel);
                }
            }
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (buyers.ContainsKey(input))
                {
                    buyers[input].BuyFood();
                }

            }


            int totalFood = 0;

            foreach (var buyer in buyers)
            {
                totalFood += buyer.Value.Food;
            }

            Console.WriteLine(totalFood);
        }
    }
}
