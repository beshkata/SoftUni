using System;
using System.Threading.Tasks;

namespace Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            string line;

            while ((line = Console.ReadLine()) != "exit")
            {
                if (line == "start")
                {
                    Task.Run(() =>
                    {
                        chronometer.Star();
                    });
                }
                else if (line == "stop")
                {
                    chronometer.Stop();
                }
                else if (line == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (line == "laps")
                {
                    if (chronometer.Laps.Count == 0)
                    {
                        Console.WriteLine("Laps: no laps");
                        continue;
                    }
                    for (int i = 0; i < chronometer.Laps.Count; i++)
                    {
                        Console.WriteLine($"{i} {chronometer.Laps[i]}");
                    }
                }
                else if (line == "reset")
                {
                    chronometer.Reset();
                }
                else if (line == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
            }
            chronometer.Stop();
        }
    }
}
