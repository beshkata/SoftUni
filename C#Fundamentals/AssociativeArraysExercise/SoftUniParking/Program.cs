using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, string> plateNumberToUser = new Dictionary<string, string>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];
                string username = input[1];

                //"register {username} {licensePlateNumber}":
                if (command == "register")
                {
                    string licensePlateNumber = input[2];
                    //so if a user tries to register another license plate, using the same username, 
                    //the system should print:
                    //"ERROR: already registered with plate number {licensePlateNumber}"
                    if (plateNumberToUser.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    //If the aforementioned checks passes successfully, the plate can be registered,
                    //so the system should print:
                    //"{username} registered {licensePlateNumber} successfully"
                    else
                    {
                        plateNumberToUser.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
                //"unregister {username}":
                else
                {
                    //If the aforementioned check passes successfully, the system should print:
                    //"{username} unregistered successfully"
                    if (plateNumberToUser.Remove(username))
                    {
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    //If the user is not present in the database, the system should print:
                    //"ERROR: user {username} not found"
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }
            // Finally Print
            //"{username} => {licensePlateNumber}"
            foreach (var kvp in plateNumberToUser)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
