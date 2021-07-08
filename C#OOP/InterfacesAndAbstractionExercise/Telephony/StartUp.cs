using System;
using Telephony.Models;

namespace Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urlAddresses = Console.ReadLine().Split();
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(phoneNumber));
                    }
                    else
                    {
                        Console.WriteLine(stationaryPhone.Call(phoneNumber));
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (string urlAddress in urlAddresses)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(urlAddress));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
