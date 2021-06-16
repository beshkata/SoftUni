using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            TimeSpan timeSpan = DateModifier.GetDifference(firstDate, secondDate);
            Console.WriteLine(Math.Abs(timeSpan.Days));
        }
    }
}
