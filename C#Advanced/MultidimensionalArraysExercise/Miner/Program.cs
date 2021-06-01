using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[n, n];
            int coalsCount = 0;
            int currentPosRow = 0;
            int currentPosCol = 0;

            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    if (currentRow[col] == 'c')
                    {
                        coalsCount++;
                    }
                    if (currentRow[col] == 's')
                    {
                        currentPosRow = row;
                        currentPosCol = col;
                    }
                    matrix[row, col] = currentRow[col];
                }
            }
            bool allCoalsCollected = false;
            bool isEndGame = false;

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "up" && AreValid(currentPosRow - 1, currentPosCol, n))
                {
                    currentPosRow--;
                }
                else if (commands[i] == "down" && AreValid(currentPosRow + 1, currentPosCol, n))
                {
                    currentPosRow++;
                }
                else if(commands[i] == "left" && AreValid(currentPosRow, currentPosCol - 1, n))
                {
                    currentPosCol--;
                }
                else if (commands[i] == "right" && AreValid(currentPosRow, currentPosCol + 1, n))
                {
                    currentPosCol++;
                }

                if (matrix[currentPosRow, currentPosCol] == 'e')
                {
                    isEndGame = true;
                    break;
                }
                else if (matrix[currentPosRow, currentPosCol] == 'c')
                {
                    coalsCount--;
                    matrix[currentPosRow, currentPosCol] = '*';
                    if (coalsCount == 0)
                    {
                        allCoalsCollected = true;
                        break;
                    }
                }
            }

            if (allCoalsCollected)
            {
                Console.WriteLine($"You collected all coals! ({currentPosRow}, {currentPosCol})");
            }
            else if (isEndGame)
            {
                Console.WriteLine($"Game over! ({currentPosRow}, {currentPosCol})");
            }
            else
            {
                Console.WriteLine($"{coalsCount} coals left. ({currentPosRow}, {currentPosCol})");
            }

        }

        private static bool AreValid(int row, int col, int dimension)
        {
            return row >= 0 && row < dimension && col >= 0 && col < dimension;
        }

    }
}
