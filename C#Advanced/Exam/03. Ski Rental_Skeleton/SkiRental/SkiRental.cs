using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    class SkiRental
    {
        private List<Ski> data;
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }

        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);

            if (ski == null)
            {
                return false;
            }
            else
            {
                data.Remove(ski);
                return true;
            }
        }

        public Ski GetNewestSki()
        {
            return data.OrderByDescending(s => s.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"The skis stored in {Name}:");

            foreach (var ski in data)
            {
                result.AppendLine(ski.ToString());
            }
            return result.ToString();
        }
    }
}
