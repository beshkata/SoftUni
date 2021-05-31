using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedMatrix = new int[n][];

            for (int row = 0; row < n; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jaggedMatrix[row] = currentRow;
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split();

                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row < 0 ||
                    row >= jaggedMatrix.GetLength(0) ||
                    col < 0 ||
                    col >= jaggedMatrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine();
                    continue;
                }

                if (command == "Add")
                {
                    jaggedMatrix[row][col] += value;
                }
                else
                {
                    jaggedMatrix[row][col] -= value;
                }

                input = Console.ReadLine();
            }

            for (int row = 0; row < jaggedMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedMatrix[row].Length; col++)
                {
                    Console.Write(jaggedMatrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
