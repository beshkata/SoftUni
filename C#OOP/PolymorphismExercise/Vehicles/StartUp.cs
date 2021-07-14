using System;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            string[] carInfo = Console.ReadLine().Split();
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine().Split();
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            string[] busInfo = Console.ReadLine().Split();
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int commandCounts = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCounts; i++)
            {
                string[] commandTokens = Console.ReadLine().Split();
                string command = commandTokens[0];
                string vehicleType = commandTokens[1];
                double amount = double.Parse(commandTokens[2]);
                try
                {
                    if (command == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(amount));
                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(amount));
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.isEmpty = false;
                            Console.WriteLine(bus.Drive(amount));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Refuel(amount);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(amount);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(amount);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        bus.isEmpty = true;
                        Console.WriteLine(bus.Drive(amount));
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {Math.Round(car.FuelQuantity,2):F2}");
            Console.WriteLine($"Truck: {Math.Round(truck.FuelQuantity,2):F2}");
            Console.WriteLine($"Bus: {Math.Round(bus.FuelQuantity,2):F2}");
        }
    }
}
