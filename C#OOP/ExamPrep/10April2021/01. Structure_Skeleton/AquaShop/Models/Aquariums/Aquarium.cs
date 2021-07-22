namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;

    public abstract class Aquarium : IAquarium
    {
        private string name;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.Decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations { get; private set; }

        public ICollection<IFish> Fish { get; private set; }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (IFish fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            string fishList = this.Fish.Count == 0 ? "none" : string.Join(", ", this.Fish.Select(f => f.Name).ToArray());
            return
                $"{this.Name} ({this.GetType().Name}):" + Environment.NewLine +
                $"Fish: {fishList}" + Environment.NewLine +
                $"Decorations: {this.Decorations.Count}" + Environment.NewLine +
                $"Comfort: {this.Comfort}";
        }

        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }
    }
}
