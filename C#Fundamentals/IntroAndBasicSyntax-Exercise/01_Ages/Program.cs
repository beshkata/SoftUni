using System;

namespace _01_Ages
{
    class Program
    {
        static void Main()
        {
            int ages = int.Parse(Console.ReadLine());

            if (ages >= 0 && ages <=2)
            {
                Console.WriteLine("baby");
            }
            else if (ages <= 13)
            {
                Console.WriteLine("child");
            }
            else if (ages <=19)
            {
                Console.WriteLine("teenager");
            }
            else if (ages <= 65)
            {
                Console.WriteLine("adult");
            }
            else
            {
                Console.WriteLine("elder");
            }
        }
    }
}
