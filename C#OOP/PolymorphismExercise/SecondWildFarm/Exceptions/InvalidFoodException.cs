using System;

namespace SecondWildFarm.Exceptions
{
    public class InvalidFoodException : Exception
    {
        public InvalidFoodException(string message)
            : base(message)
        {

        }
    }
}
