using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            Dyes = new List<IDye>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                this.name = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.energy = value;
            }
        }

        public ICollection<IDye> Dyes { get; private set; }

        public virtual void Work()
        {
            Energy -= 10;
            if (Energy < 0)
            {
                Energy = 0;
            }

        }

        public void AddDye(IDye dye)
        {
            Dyes.Add(dye);
        }

        public override string ToString()
        {
            List<IDye> notFinishedDyes = Dyes.Where(d => d.IsFinished() == false).ToList();
            return
                $"Name: {Name}" + Environment.NewLine +
                $"Energy: {Energy}" + Environment.NewLine +
                $"Dyes: {notFinishedDyes.Count} not finished";
        }
    }
}
