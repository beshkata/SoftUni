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
            string text = "";
            Stack<string> undo = new Stack<string>();
            undo.Push(text);


            for (int i = 0; i < n; i++)
            {
                string commandInfo = Console.ReadLine();
                string[] tokens = commandInfo.Split();
                string command = tokens[0];

                if (command == "1")
                {
                    undo.Push(text);
                    text = text + tokens[1];
                    
                    
                }
                else if (command == "2")
                {
                    int lenght = int.Parse(tokens[1]);
                    undo.Push(text);
                    text = text.Remove(text.Length - lenght, lenght);
                    
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
