using System;
using System.Linq;
using System.Collections.Generic;

namespace ReVolt
{
    class Player
    {

        public int Row { get; set; }
        public int Col { get; set; }

        public void MoveLeft(int matrixSize)
        {
            if (Col-1 < 0)
            {
                Col = matrixSize - 1;
            }
            else
            {
                Col--;
            }
        }
        public void MoveRight(int matrixSize)
        {

            if (Col + 1 == matrixSize)
            {
                Col = 0;
            }
            else
            {
                Col++;
            }
        }
        public void MoveUp(int matrixSize)
        {
            if (Row - 1 < 0)
            {
                Row = matrixSize - 1;
            }
            else
            {
                Row--;
            }
            
        }
        public void MoveDown(int matrixSize)
        {
            if (Row + 1 == matrixSize)
            {
                Row = 0;
            }
            else
            {
                Row++;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int commandNumber = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            Player player = new Player();

            for (int row = 0; row < matrixSize; row++)
            {
                char[] currRow = Console.ReadLine()
                    .ToCharArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = currRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        player.Row = row;
                        player.Col = col;
                    }

                }
            }
            bool isWinner = false;
            char previosChar = '-';
            for (int i = 0; i < commandNumber; i++)
            {
                string command = Console.ReadLine();

                if (command == "left")
                {
                    matrix[player.Row, player.Col] = previosChar;
                    player.MoveLeft(matrixSize);
                    if (matrix[player.Row, player.Col] == 'B')
                    {
                        
                        player.MoveLeft(matrixSize);
                        previosChar = matrix[player.Row, player.Col];
                    }
                    else if (matrix[player.Row, player.Col] == 'F')
                    {
                        matrix[player.Row, player.Col] = 'f';
                        isWinner = true;
                        break;
                    }
                    else if (matrix[player.Row, player.Col] == 'T')
                    {
                        player.MoveRight(matrixSize);
                    }
                    matrix[player.Row, player.Col] = 'f';
                }
                else if (command == "right")
                {
                    matrix[player.Row, player.Col] = previosChar;
                    player.MoveRight(matrixSize);
                    if (matrix[player.Row, player.Col] == 'B')
                    {

                        player.MoveRight(matrixSize);
                        previosChar = matrix[player.Row, player.Col];
                    }
                    else if (matrix[player.Row, player.Col] == 'F')
                    {
                        matrix[player.Row, player.Col] = 'f';
                        isWinner = true;
                        break;
                    }
                    else if (matrix[player.Row, player.Col] == 'T')
                    {
                        player.MoveLeft(matrixSize);
                    }
                    matrix[player.Row, player.Col] = 'f';

                }
                else if (command == "up")
                {
                    matrix[player.Row, player.Col] = previosChar;
                    player.MoveUp(matrixSize);
                    if (matrix[player.Row, player.Col] == 'B')
                    {

                        player.MoveUp(matrixSize);
                        previosChar = matrix[player.Row, player.Col];
                    }
                    else if (matrix[player.Row, player.Col] == 'F')
                    {
                        matrix[player.Row, player.Col] = 'f';
                        isWinner = true;
                        break;
                    }
                    else if (matrix[player.Row, player.Col] == 'T')
                    {
                        player.MoveDown(matrixSize);
                    }
                    matrix[player.Row, player.Col] = 'f';


                }
                else
                {
                    matrix[player.Row, player.Col] = previosChar;
                    player.MoveDown(matrixSize);
                    if (matrix[player.Row, player.Col] == 'B')
                    {

                        player.MoveDown(matrixSize);
                        previosChar = matrix[player.Row, player.Col];
                    }
                    else if (matrix[player.Row, player.Col] == 'F')
                    {
                        matrix[player.Row, player.Col] = 'f';
                        isWinner = true;
                        break;
                    }
                    else if (matrix[player.Row, player.Col] == 'T')
                    {
                        player.MoveUp(matrixSize);
                    }
                    matrix[player.Row, player.Col] = 'f';

                }
            }
            if (isWinner)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(matrix);

        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
