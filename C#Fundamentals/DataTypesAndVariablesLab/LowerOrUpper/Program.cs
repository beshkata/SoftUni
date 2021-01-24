using System;

namespace LowerOrUpper
{
    class Program
    {
        static void Main()
        {
            //A - 65, Z - 90, a - 97, z - 122
            char input = char.Parse(Console.ReadLine());
            if (input >= 65 && input <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
