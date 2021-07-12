using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Height { get; private set; }
        public int Width { get; private set; }
        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Height + 2 * Width;
        }

        public override string Draw()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(new string('*', Width));
            for (int i = 0; i < Height - 1; i++)
            {
                result.AppendLine(new string('*', 1) + new string(' ', Width - 2) + new string('*', 1));
            }
            result.AppendLine(new string('*', Width));
            return result.ToString();
        }
    }
}
