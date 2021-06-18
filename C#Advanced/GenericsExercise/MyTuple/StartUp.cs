using System;

namespace MyTuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();
            string fullName = $"{firstLine[0]} {firstLine[1]}";
            string address = firstLine[2];

            MyTuple<string, string> firstLineTuple = new MyTuple<string, string>(fullName, address);
            Console.WriteLine(firstLineTuple);

            string[] secondLine = Console.ReadLine().Split();
            string name = secondLine[0];
            int amountOfBeer = int.Parse(secondLine[1]);

            MyTuple<string, int> secondLineTuple = new MyTuple<string, int>(name, amountOfBeer);
            Console.WriteLine(secondLineTuple);

            string[] thirdLine = Console.ReadLine().Split();
            int integer = int.Parse(thirdLine[0]);
            double realNum = double.Parse(thirdLine[1]);

            MyTuple<int, double> thirdLineTuple = new MyTuple<int, double>(integer, realNum);
            Console.WriteLine(thirdLineTuple);
        }
    }
}
