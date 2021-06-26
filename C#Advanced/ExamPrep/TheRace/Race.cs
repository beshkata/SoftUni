using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data = new List<Racer>();
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = data.FirstOrDefault(r => r.Name == name);
            if (racer == null)
            {
                return false;
            }
            else
            {
                data.Remove(racer);
                return true;
            }
        }
        public Racer GetRacer(string name)
        {
            Racer racer = data.FirstOrDefault(r => r.Name == name);
            return racer;
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(r => r.Age).FirstOrDefault();
        }
        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Racers participating at {Name}:");
            foreach (var racer in data)
            {
                result.AppendLine(racer.ToString());
            }

            return result.ToString();
        }
    }
}
