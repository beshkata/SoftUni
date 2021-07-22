using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != nameof(FreshwaterAquarium) && aquariumType != nameof(SaltwaterAquarium))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            IAquarium aquarium = null;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != nameof(Ornament) && decorationType != nameof(Plant))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            IDecoration decoration = null;

            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }

            decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);

        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != nameof(FreshwaterFish) && fishType != nameof(SaltwaterFish))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            IFish fish = null;

            if (fishType == nameof(FreshwaterFish))
            {
                if (aquarium.GetType().Name == nameof(SaltwaterAquarium))
                {
                    return OutputMessages.UnsuitableWater;
                }

                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                if (aquarium.GetType().Name == nameof(FreshwaterAquarium))
                {
                    return OutputMessages.UnsuitableWater;
                }
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            aquarium.AddFish(fish);
            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);

        }

        public string CalculateValue(string aquariumName)
        {
            decimal value = 0;
            IAquarium aquarium = aquariums.FirstOrDefault(n => n.Name == aquariumName);

            value += aquarium.Fish.Sum(f => f.Price);
            value += aquarium.Decorations.Sum(d => d.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(n => n.Name == aquariumName);

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquarium.Decorations.Add(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
