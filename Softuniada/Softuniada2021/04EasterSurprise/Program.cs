using System;
using System.Collections.Generic;
using System.Linq;

namespace _04EasterSurprise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = ReadMatrix(dimensions[0], dimensions[1]);

            char symbolFound = char.Parse(Console.ReadLine());

            int[] startCoordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Position startingPosition = new Position(startCoordinates[0], startCoordinates[1]);

            char initialSymbol = startingPosition.CheckPosition(matrix);

            Position currentPosition = new Position(startingPosition.Row, startingPosition.Col);

            List<Position> positions = new List<Position>();

            bool hasGoodBox = true;

            while (hasGoodBox)
            {
                hasGoodBox = currentPosition.CheckNearPositions(matrix, initialSymbol, symbolFound, positions);
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
    }

    class Position
    {
        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }
        public int Row { get; set; }
        public int Col { get; set; }

        public char CheckPosition(char[,] matrix)
        {
            return matrix[Row, Col];
        }

        public bool CheckNearPositions(char[,] matrix, 
            char initialSymbol,
            char symbolFound, 
            List<Position> positions)
        {
            bool hasGoodPosition = true;
            if(this.IsValidPosition(matrix))
            {
                ChangeSymbol(matrix, symbolFound);
                positions.Remove(this);
            }
            Position leftPosition = new Position(Row - 1, Col);
            Position rightPosition = new Position(Row + 1, Col);
            Position upPosition = new Position(Row, Col - 1);
            Position downPosition = new Position(Row, Col + 1);

            if (leftPosition.IsValidPosition(matrix)
                && leftPosition.CheckPosition(matrix) == initialSymbol)
            {
                positions.Add(leftPosition);
            }

            if (rightPosition.IsValidPosition(matrix)
                && rightPosition.CheckPosition(matrix) == initialSymbol)
            {
                positions.Add(rightPosition);
            }

            if (upPosition.IsValidPosition(matrix)
                && upPosition.CheckPosition(matrix) == initialSymbol)
            {
                positions.Add(upPosition);
            }

            if (downPosition.IsValidPosition(matrix)
                && downPosition.CheckPosition(matrix) == initialSymbol)
            {
                positions.Add(downPosition);
            }

            Position newPosition = positions.FirstOrDefault();
            positions.Remove(newPosition);
            if (newPosition != null)
            {
                Row = newPosition.Row;
                Col = newPosition.Col;
            }
            else
            {
                hasGoodPosition = false;
            }
            
            return hasGoodPosition;

        }

        private void ChangeSymbol(char[,] matrix, char symbolFound)
        {
            matrix[Row, Col] = symbolFound;
        }

        private bool IsValidPosition(char[,] matrix)
        {
            return Row >= 0 && Row < matrix.GetLength(0) && Col >= 0 && Col < matrix.GetLength(1);
        }
    }
}
