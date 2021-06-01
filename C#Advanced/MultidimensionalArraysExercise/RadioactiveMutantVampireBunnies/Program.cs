using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int currPosRow = 0;
            int currPosCol = 0;
            List<int[]> bunnies = new List<int[]>();

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    if (currentRow[col] == 'B')
                    {
                        bunnies.Add(new int[2] { row, col });
                    }
                    else if (currentRow[col] == 'P')
                    {
                        currPosRow = row;
                        currPosCol = col;
                    }
                    matrix[row, col] = currentRow[col];
                }
            }

            string commands = Console.ReadLine();
            bool isPlayerWon = false;
            bool isPlayerDead = false;

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == 'U')
                {
                    if (AreValid(currPosRow - 1, currPosCol, rows, cols) == false)
                    {
                        isPlayerWon = true;
                        matrix[currPosRow, currPosCol] = '.';
                    }
                    else if (matrix[currPosRow - 1, currPosCol] == 'B')
                    {
                        isPlayerDead = true;
                        currPosRow--;
                    }
                    else if (matrix[currPosRow - 1, currPosCol] == '.')
                    {
                        matrix[currPosRow, currPosCol] = '.';
                        matrix[currPosRow - 1, currPosCol] = 'P';
                        currPosRow--;
                    }
                }
                else if (commands[i] == 'D')
                {
                    if (AreValid(currPosRow + 1, currPosCol, rows, cols) == false)
                    {
                        isPlayerWon = true;
                        matrix[currPosRow, currPosCol] = '.';
                    }
                    else if (matrix[currPosRow + 1, currPosCol] == 'B')
                    {
                        isPlayerDead = true;
                        currPosRow++;
                    }
                    else if (matrix[currPosRow + 1, currPosCol] == '.')
                    {
                        matrix[currPosRow, currPosCol] = '.';
                        matrix[currPosRow + 1, currPosCol] = 'P';
                        currPosRow++;
                    }
                }
                else if (commands[i] == 'L')
                {
                    if (AreValid(currPosRow, currPosCol - 1, rows, cols) == false)
                    {
                        isPlayerWon = true;
                        matrix[currPosRow, currPosCol] = '.';
                    }
                    else if (matrix[currPosRow, currPosCol - 1] == 'B')
                    {
                        isPlayerDead = true;
                        currPosCol--;
                    }
                    else if (matrix[currPosRow, currPosCol - 1] == '.')
                    {
                        matrix[currPosRow, currPosCol] = '.';
                        matrix[currPosRow, currPosCol - 1] = 'P';
                        currPosCol--;
                    }
                }
                if (commands[i] == 'R')
                {
                    if (AreValid(currPosRow, currPosCol + 1, rows, cols) == false)
                    {
                        isPlayerWon = true;
                        matrix[currPosRow, currPosCol] = '.';
                    }
                    else if (matrix[currPosRow, currPosCol + 1] == 'B')
                    {
                        isPlayerDead = true;
                        currPosCol++;
                    }
                    else if (matrix[currPosRow, currPosCol + 1] == '.')
                    {
                        matrix[currPosRow, currPosCol] = '.';
                        matrix[currPosRow, currPosCol + 1] = 'P';
                        currPosCol++;
                    }
                }

                for (int j = 0; j < bunnies.Count; j++)
                {
                    int bunnyRow = bunnies[j][0];
                    int bunnyCol = bunnies[j][1];

                    if (AreValid(bunnyRow, bunnyCol + 1, rows, cols))
                    {
                        if (matrix[bunnyRow, bunnyCol + 1] == 'P')
                        {
                            isPlayerDead = true;
                            matrix[bunnyRow, bunnyCol + 1] = 'B';
                        }
                        else
                        {
                            matrix[bunnyRow, bunnyCol + 1] = 'B';
                        }
                    }
                    if (AreValid(bunnyRow, bunnyCol - 1, rows, cols))
                    {
                        if (matrix[bunnyRow, bunnyCol - 1] == 'P')
                        {
                            isPlayerDead = true;
                            matrix[bunnyRow, bunnyCol - 1] = 'B';
                        }
                        else
                        {
                            matrix[bunnyRow, bunnyCol - 1] = 'B';
                        }
                    }
                    if (AreValid(bunnyRow + 1, bunnyCol, rows, cols))
                    {
                        if (matrix[bunnyRow + 1, bunnyCol] == 'P')
                        {
                            isPlayerDead = true;
                            matrix[bunnyRow + 1, bunnyCol] = 'B';
                        }
                        else
                        {
                            matrix[bunnyRow + 1, bunnyCol] = 'B';
                        }
                    }
                    if (AreValid(bunnyRow - 1, bunnyCol, rows, cols))
                    {
                        if (matrix[bunnyRow - 1, bunnyCol] == 'P')
                        {
                            isPlayerDead = true;
                            matrix[bunnyRow - 1, bunnyCol] = 'B';
                        }
                        else
                        {
                            matrix[bunnyRow - 1, bunnyCol] = 'B';
                        }
                    }
                    //PrintMatrix(rows, cols, matrix);
                    //Console.WriteLine();
                }
                if (isPlayerDead || isPlayerWon)
                {
                    break;
                }

                bunnies = CountBunies(matrix, bunnies);

            }
            PrintMatrix(rows, cols, matrix);

            if (isPlayerDead)
            {
                Console.WriteLine($"dead: {currPosRow} {currPosCol}");
            }
            else if (isPlayerWon)
            {
                Console.WriteLine($"won: {currPosRow} {currPosCol}");
            }

        }

        private static void PrintMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static List<int[]> CountBunies(char[,] matrix, List<int[]> bunnies)
        {
            bunnies.Clear();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == 'B')
                    {
                        bunnies.Add(new int[2] { row, col });
                    }
                }
            }
            return bunnies;
        }

        private static bool AreValid(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }

    }
}
