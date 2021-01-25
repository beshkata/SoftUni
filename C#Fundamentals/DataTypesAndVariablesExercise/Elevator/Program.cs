using System;

namespace Elevator
{
    class Program
    {
        static void Main()
        {
            int personCount = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            int result = (int)Math.Ceiling((double)personCount / elevatorCapacity);
            Console.WriteLine(result);
        }
    }
}
