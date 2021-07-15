using System;
using System.Collections.Generic;
using System.Text;

namespace SecondWildFarm.IO.Writers
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
