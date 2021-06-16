using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>(this.capacity);
        }
        public int Count { get => cars.Count; }

        public void AddCar(Car car)
        {
            if (!cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                if (cars.Count < capacity)
                {
                    cars.Add(car);
                    Console.WriteLine($"Successfully added new car {car.Make} {car.RegistrationNumber}");
                }
                else
                {
                    Console.WriteLine("Parking is full!");
                }
            }
            else
            {
                Console.WriteLine("Car with that registration number, already exists!");
            }
        }

        public void RemoveCar(string registrationNumber)
        {
            if (!cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                Console.WriteLine("Car with that registration number, doesn't exist!");
            }
            else
            {
                int index = 0;
                for (int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].RegistrationNumber == registrationNumber)
                    {
                        index = i;
                        break;
                    }
                }
                cars.RemoveAt(index);
                Console.WriteLine($"Successfully removed {registrationNumber}");
            }
        }

        public Car GetCar(string registrationNumber)
        {
            int index = 0;
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].RegistrationNumber == registrationNumber)
                {
                    index = i;
                    break;
                }
            }

            Car car = cars[index];
            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            for (int i = 0; i < registrationNumbers.Count; i++)
            {
                if (cars.Any(c => c.RegistrationNumber == registrationNumbers[i]))
                {
                    for (int j = 0; j < cars.Count; j++)
                    {
                        if (cars[i].RegistrationNumber == registrationNumbers[i])
                        {
                            cars.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }
    }
}
