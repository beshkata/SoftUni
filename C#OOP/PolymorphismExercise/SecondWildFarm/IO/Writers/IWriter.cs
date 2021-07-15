using System;
using System.Collections.Generic;
using System.Text;

namespace SecondWildFarm.IO.Writers
{
    public interface IWriter
    {
        public void WriteLine(string message);
    }
}
