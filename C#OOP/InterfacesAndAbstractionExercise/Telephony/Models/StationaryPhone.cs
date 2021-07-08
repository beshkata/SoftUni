using System;
using System.Linq;
using Telephony.Contracts;

namespace Telephony.Models
{
    class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (phoneNumber.All(x => char.IsDigit(x)))
            {
                return $"Dialing... {phoneNumber}";
            }
            else
            {
                throw new ArgumentException("Invalid number!");
            }
        }
    }
}
