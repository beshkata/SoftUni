using System;

namespace CenturiesToMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int centeries = int.Parse(Console.ReadLine());
            int years = centeries * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            long minutes = hours * 60;

            Console.WriteLine($"{centeries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
