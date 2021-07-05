using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                ThrowIfArgumentIsNegativeOrZero(value, $"{nameof(Length)} cannot be zero or negative.");
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                ThrowIfArgumentIsNegativeOrZero(value, $"{nameof(Width)} cannot be zero or negative.");
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                ThrowIfArgumentIsNegativeOrZero(value, $"{nameof(Height)} cannot be zero or negative.");
                this.height = value;
            }
        }

        public double CalcLateralSurfaceArea()
        {
            //2lh + 2wh
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double CalcSurfaceArea()
        {
            //2lw + 2lh + 2wh
            return 2 * Length * Width + CalcLateralSurfaceArea();
        }

        public double CalcVolume()
        {
            return Length * Width * Height;
        }

        private void ThrowIfArgumentIsNegativeOrZero(double value, string message)
        {
            if (value <= 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
