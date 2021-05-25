using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //string text = "";
            StringBuilder text = new StringBuilder();
            Stack<StringBuilder> undo = new Stack<StringBuilder>();
            StringBuilder savedText = new StringBuilder();
            undo.Push(text);


            for (int i = 0; i < n; i++)
            {
                string commandInfo = Console.ReadLine();
                string[] tokens = commandInfo.Split();
                string command = tokens[0];

                if (command == "1")
                {
                    text.Append(tokens[1]);
                    savedText = text;
                    undo.Push(savedText);
                }
                else if (command == "2")
                {
                    int lenght = int.Parse(tokens[1]);
                    text.Remove(text.Length - lenght, lenght);
                    undo.Push(text);
                }
                else if (command == "3")
                {
                    int index = int.Parse(tokens[1]);
                    Console.WriteLine(text[index-1]);
                }
                else
                {
                    text = undo.Pop();
                }
            }
        }
    }
}
