using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string name = "sdkw";
            dic.Add(name, "dsw");

            Console.WriteLine(dic["sdkw"]);
        }
    }
}
