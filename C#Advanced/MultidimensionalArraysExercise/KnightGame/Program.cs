using System;
using System.Linq;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            
            int knightRemoved = 0;
            bool isFinished = false;

            while (isFinished == false)
            {
                int maxAttacks = 0;
                int bestRow = 0;
                int bestCol = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        int attackCounter = 0;
                        if (matrix[row, col] == 'K')
                        {
                            attackCounter = CountingAttaks(n, matrix, row, col, attackCounter);
                        }

                        if (attackCounter > maxAttacks)
                        {
                            maxAttacks = attackCounter;
                            bestRow = row;
                            bestCol = col;
                        }
                    }
                }

                if (maxAttacks> 0)
                {
                    matrix[bestRow, bestCol] = '0';
                    knightRemoved++;
                }
                else
                {
                    isFinished = true;
                }
            }


            Console.WriteLine(knightRemoved);
        }

        private static int CountingAttaks(int n, char[,] matrix, int row, int col, int attackCounter)
        {
            if (AreValid(row - 1, col - 2, n) && matrix[row - 1, col - 2] == 'K')
            {
                attackCounter++;
            }
            if (AreValid(row - 2, col - 1, n) && matrix[row - 2, col - 1] == 'K')
            {
                attackCounter++;
            }
            if (AreValid(row - 2, col + 1, n) && matrix[row - 2, col + 1] == 'K')
            {
                attackCounter++;
            }
            if (AreValid(row - 1, col + 2, n) && matrix[row - 1, col + 2] == 'K')
            {
                attackCounter++;
            }
            if (AreValid(row + 1, col + 2, n) && matrix[row + 1, col + 2] == 'K')
            {
                attackCounter++;
            }
            if (AreValid(row + 2, col + 1, n) && matrix[row + 2, col + 1] == 'K')
            {
                attackCounter++;
            }
            if (AreValid(row + 2, col - 1, n) && matrix[row + 2, col - 1] == 'K')
            {
                attackCounter++;
            }
            if (AreValid(row + 1, col - 2, n) && matrix[row + 1, col - 2] == 'K')
            {
                attackCounter++;
            }

            return attackCounter;
        }

        private static bool AreValid(int row, int col, int dimension)
        {
            return row >= 0 && row < dimension && col >= 0 && col < dimension;
        }
    }
}
