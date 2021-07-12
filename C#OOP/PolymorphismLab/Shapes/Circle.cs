using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private int radius;

        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public int Radius { get; private set; }
        public override double CalculateArea()
        {
            return 3.14* Radius * radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * 3.14 * Radius;
        }

        public override string Draw()
        {
            StringBuilder result = new StringBuilder();
            double rIn = this.Radius - 0.4;
            double rOut = this.Radius + 0.4;
            for (double y = this.Radius; y >= -this.Radius; --y)
            {
                for (double x = -this.Radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                        result.Append("*");
                    else
                        result.Append(" ");
                }
                result.AppendLine();
            }
            return result.ToString();
        }

    }
}
