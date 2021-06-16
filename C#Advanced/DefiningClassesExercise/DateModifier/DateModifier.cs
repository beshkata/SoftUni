using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        private string differece;

        public static TimeSpan GetDifference(string firstDate, string secondDate)
        {
            int[] firstTokens = firstDate
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            DateTime startDate = new DateTime(firstTokens[0], firstTokens[1], firstTokens[2]);

            int[] secondTokens = secondDate
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            DateTime endDate = new DateTime(secondTokens[0], secondTokens[1], secondTokens[2]);

            return (endDate - startDate);
        }
    }
}
