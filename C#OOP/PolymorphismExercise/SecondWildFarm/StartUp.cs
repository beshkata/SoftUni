using SecondWildFarm.Core;
using SecondWildFarm.IO.Readers;
using SecondWildFarm.IO.Writers;

namespace SecondWildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
