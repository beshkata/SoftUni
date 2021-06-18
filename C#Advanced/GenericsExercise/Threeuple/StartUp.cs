using System;
using System.Linq;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();

            string fullName = $"{firstLine[0]} {firstLine[1]}";
            string address = firstLine[2];
            string town = string.Join(' ', firstLine.Skip(3));
            Threeuple<string, string, string> firstThreeuple = 
                new Threeuple<string, string, string>(fullName, address, town);
            Console.WriteLine(firstThreeuple);

            string[] secondLine = Console.ReadLine().Split();
            string nameSecondLine = secondLine[0];
            int amountOfBeer = int.Parse(secondLine[1]);
            bool isDrunk = secondLine[2] == "drunk" ? true : false;

            Threeuple<string, int, bool> secondLineThreeuple =
                new Threeuple<string, int, bool>(nameSecondLine, amountOfBeer, isDrunk);
            Console.WriteLine(secondLineThreeuple);

            string[] thirdLine = Console.ReadLine().Split();
            string nameThirdLine = thirdLine[0];
            double accountBalance = double.Parse(thirdLine[1]);
            string bankName = string.Join(' ', thirdLine.Skip(2));

            Threeuple<string, double, string> thirdLineThreeuple =
                new Threeuple<string, double, string>(nameThirdLine, accountBalance, bankName);
            Console.WriteLine(thirdLineThreeuple);
        }
    }
}
