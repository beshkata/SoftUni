using System;
using System.Linq;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main()
        {
            int inputsCount = int.Parse(Console.ReadLine());
            double[] inputsEncrypt = new double[inputsCount];

            for (int i = 0; i < inputsCount; i++)
            {
                string input = Console.ReadLine();
                double currentSum = 0.0;

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'A' || input[j] == 'a' || input[j] == 'E' || input[j] == 'e' ||
                        input[j] == 'I' || input[j] == 'i' || input[j] == 'O' || input[j] == 'o' ||
                        input[j] == 'U' || input[j] == 'u')
                    {
                        currentSum += input[j] * input.Length;
                    }
                    else
                    {
                        currentSum += input[j] / input.Length;
                    }
                }
                inputsEncrypt[i] = currentSum;
            }
            Array.Sort(inputsEncrypt);

            for (int i = 0; i < inputsEncrypt.Length; i++)
            {
                Console.WriteLine(inputsEncrypt[i]);
            }
        }
    }
}
