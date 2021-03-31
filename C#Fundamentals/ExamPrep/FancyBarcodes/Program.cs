using System;
using System.Text.RegularExpressions;
using System.Text;

namespace FancyBarcodes
{
    class Program
    {
        static void Main()
        {
            string barcodePattern = @"^(@#+)([A-Z][A-Za-z\d]{4,}[A-Z])(@#+)$";
            string digitPattern = @"\d";

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string barcode = Console.ReadLine();

                Match match = Regex.Match(barcode, barcodePattern);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                MatchCollection digitMatches = Regex.Matches(barcode, digitPattern);
                StringBuilder productGroup = new StringBuilder();

                if (digitMatches.Count == 0)
                {
                    productGroup.Append("00");
                }
                else
                {
                    foreach (Match digit in digitMatches)
                    {
                        productGroup.Append(digit.ToString());
                    }
                }

                Console.WriteLine($"Product group: {productGroup}");
            }
        }
    }
}
