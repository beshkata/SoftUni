using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main()
        {
            string book = Console.ReadLine();

            string currentBook = Console.ReadLine();
            int counter = 0;

            while (currentBook != book)
            {
                if (currentBook == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;
                }
                counter++;
                currentBook = Console.ReadLine();
            }
            if (currentBook == book)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
        }
    }
}
