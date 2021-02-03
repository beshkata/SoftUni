using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bestSequence = 0;
            int numberBestSequence = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                int currentSequence = 1;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] == currentNumber)
                    {
                        currentSequence++;
                    }
                    else
                    {
                        break;
                    }
                }
                
                if (currentSequence > bestSequence)
                {
                    bestSequence = currentSequence;
                    numberBestSequence = currentNumber;
                }
            }

            for (int i = 0; i < bestSequence; i++)
            {
                Console.Write($"{numberBestSequence} ");
            }
        }
    }
}
