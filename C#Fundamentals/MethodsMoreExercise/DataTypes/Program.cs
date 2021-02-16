using System;

namespace DataTypes
{
    class Program
    {
        static void Main()
        {
            string dataType = Console.ReadLine();
            string input = Console.ReadLine();

            if (dataType == "int")
            {
                int intNum = int.Parse(input);
                ManipulateDataTypes(intNum);
            }
            else if (dataType == "real")
            {
                double doubleNum = double.Parse(input);
                ManipulateDataTypes(doubleNum);
            }
            else
            {
                ManipulateDataTypes(input);
            }
        }

        private static void ManipulateDataTypes(string str)
        {
            Console.WriteLine($"${str}$");
        }

        private static void ManipulateDataTypes(double doubleNum)
        {
            Console.WriteLine($"{doubleNum * 1.5:f2}");
        }

        private static void ManipulateDataTypes(int intNum)
        {
            Console.WriteLine(intNum * 2);
        }
    }
}
