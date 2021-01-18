using System;

namespace _09_PadawanEquipment
{
    class Program
    {
        static void Main()
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            int lightsabersNumber = (int)(studentsCount + studentsCount * 0.1);

            if (studentsCount % 10 != 0)
            {
                lightsabersNumber++;
            }

            int beltsNumber = studentsCount - (studentsCount / 6);

            double moneyNeeded = (lightsabersNumber* lightsaberPrice + beltsNumber* beltsPrice
                + studentsCount* robePrice) * 1.0;
            if (amountOfMoney >= moneyNeeded)
            {
                Console.WriteLine($"The money is enough - it would cost {moneyNeeded:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {moneyNeeded - amountOfMoney:f2}lv more.");
            }
        }
    }
}
