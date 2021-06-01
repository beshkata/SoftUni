using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                matrix[row] = currentRow;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row+1].Length)
                {
                    matrix[row] = matrix[row].Select(Multiply).ToArray();
                    matrix[row+1] = matrix[row+1].Select(Multiply).ToArray();
                }
                else
                {
                    matrix[row] = matrix[row].Select(Divide).ToArray();
                    matrix[row+1] = matrix[row+1].Select(Divide).ToArray();
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (AreValid(row, col, matrix))
                {
                    if (command == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    else
                    {
                        matrix[row][col] -= value;
                    }
                }
                input = Console.ReadLine();
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(' ', matrix[row]));
            }
        }

        private static bool AreValid(int row, int col, double[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }

        static double Multiply(double number)
        {
            return number * 2;
        }

        static double Divide(double number)
        {
            return number / 2;
        }
    }
}
