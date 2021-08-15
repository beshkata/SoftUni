using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int MinModelSymbols = 4;

        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get
            {
                return model;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinModelSymbols)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, MinModelSymbols));
                }

                model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return horsePower;
            }
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
