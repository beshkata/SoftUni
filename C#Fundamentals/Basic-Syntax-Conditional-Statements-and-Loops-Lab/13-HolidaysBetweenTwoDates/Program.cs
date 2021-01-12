using System;
using System.Globalization;

class HolidaysBetweenTwoDates
{
    static void Main()
    {
        string[] formats = { "dd.MM.yyyy", "d.MM.yyyy", "d.M.yyyy", "dd.M.yyyy" };
        var startDate = DateTime.ParseExact(Console.ReadLine(), formats, CultureInfo.InvariantCulture);
        var endDate = DateTime.ParseExact(Console.ReadLine(),
            formats, CultureInfo.InvariantCulture);
        var holidaysCount = 0;
        for (var date = startDate; date <= endDate; date = date.AddDays(1))
        {
            if (date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday)
            {
                holidaysCount++;
            }
        }
        Console.WriteLine(holidaysCount);
    }
}