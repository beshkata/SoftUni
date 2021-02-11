using System;

namespace CalculateRectangleArea
{
    class Program
    {
        static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int area = GetRectangleArea(width, height);
            Console.WriteLine(area);
        }

        private static int GetRectangleArea(int width, int height)
        {
            return width * height;
        }
    }
}
