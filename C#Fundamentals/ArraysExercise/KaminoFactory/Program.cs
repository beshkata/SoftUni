using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main()
        {
            int sequenceLength = int.Parse(Console.ReadLine());
            int sampleCounter = 1;
            int bestSequenceLength = 0;
            int bestSequenceIndex = 0;
            int bestSampleNumber = 1;
            int bestSampleSum = 0;
            int[] bestDNALine = new int[sequenceLength];

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Clone them!")
                {
                    break;
                }

                int[] line = input
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentSampleSum = 0;

                foreach (var item in line)
                {
                    currentSampleSum += item;
                }
                int currentSequenceLength = 0;
                

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == 0)
                    {
                        continue;
                    }
                    int currentSequenceIndex = i;
                    for (int j = i + 1; j < line.Length; j++)
                    {
                        if (line[i] == line[j])
                        {
                            currentSequenceLength++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (currentSequenceLength > bestSequenceLength)
                    {
                        bestSequenceLength = currentSequenceLength;
                        bestSequenceIndex = currentSequenceIndex;
                        bestSampleNumber = sampleCounter;
                        bestSampleSum = currentSampleSum;
                        bestDNALine = line;
                    }
                    else if (currentSequenceLength == bestSequenceLength && currentSequenceIndex < bestSequenceIndex)
                    {
                        bestSequenceLength = currentSequenceLength;
                        bestSequenceIndex = currentSequenceIndex;
                        bestSampleNumber = sampleCounter;
                        bestSampleSum = currentSampleSum;
                        bestDNALine = line;
                    }
                    else if (currentSequenceLength == bestSequenceLength && currentSequenceIndex == bestSequenceIndex && currentSampleSum > bestSampleSum)
                    {
                        bestSequenceLength = currentSequenceLength;
                        bestSequenceIndex = currentSequenceIndex;
                        bestSampleNumber = sampleCounter;
                        bestSampleSum = currentSampleSum;
                        bestDNALine = line;
                    }
                }
                sampleCounter += 1;
            }
            Console.WriteLine($"Best DNA sample {bestSampleNumber} with sum: {bestSampleSum}.");
            Console.WriteLine(string.Join(' ', bestDNALine));
        }
    }
}
