using System;
using System.Text;

namespace LongerLine
{
    class Program
    {
        static void Main()
        {
            Point point1 = new Point(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Point point2 = new Point(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));

            Line line1 = new Line(point1, point2);

            Point point3 = new Point(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            Point point4 = new Point(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));

            Line line2 = new Line(point3, point4);

            if (line1.Lenght >= line2.Lenght )
            {
                Console.WriteLine(line1.ToString());
            }
            else
            {
                Console.WriteLine(line2.ToString());
            }

        }
    }
    class Line
    {
        public Line (Point firstPoint, Point secondPoint)
        {
            Point[] points = GetStartAndEndPoints(firstPoint, secondPoint);
            StartPoint = points[0];
            EndPoint = points[1];
            Lenght = GetLineLenght();
        }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public double Lenght { get; set; }
        private static Point[] GetStartAndEndPoints(Point firstPoint, Point secondPoint)
        {
            double firstPointDistanceToCentre = firstPoint.GetPointDistanceToCentre();
            double secondPointDistanceToCentre = secondPoint.GetPointDistanceToCentre();

            Point[] points = new Point[2];

            if (firstPointDistanceToCentre <= secondPointDistanceToCentre)
            {
                points[0] = firstPoint;
                points[1] = secondPoint;
            }
            else
            {
                points[0] = secondPoint;
                points[1] = firstPoint;
            }
            return points;
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"{StartPoint}{EndPoint}");

            return stringBuilder.ToString();
        }

        private double GetLineLenght()
        {
            double lenght = StartPoint.GetPointDistanceToCentre() + EndPoint.GetPointDistanceToCentre();
            return lenght;
        }

    }
    class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"({X}, {Y})");

            return stringBuilder.ToString();
        }

        public double GetPointDistanceToCentre()
        {
            double distance = Math.Sqrt(Math.Pow(Math.Abs(X), 2) + Math.Pow(Math.Abs(Y), 2));
            return distance;
        }

    }

}
