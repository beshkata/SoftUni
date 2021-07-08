using System;
using System.Linq;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Browse(string urlAddress)
        {
            if (urlAddress.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }
            else
            {
                return $"Browsing: {urlAddress}!";
            }
        }

        public string Call(string phoneNumber)
        {
            if (phoneNumber.All(x => char.IsDigit(x)))
            {
                return $"Calling... {phoneNumber}";
            }
            else
            {
                throw new ArgumentException("Invalid number!");
            }
        }
    }
}
