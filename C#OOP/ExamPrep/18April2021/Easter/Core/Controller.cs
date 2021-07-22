using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private IRepository<IBunny> bunnies;
        private IRepository<IEgg> eggs;
        private int coloredEggsCount = 0;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;
            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            bunny.AddDye(new Dye(power));
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = eggs.FindByName(eggName);

            IWorkshop workshop = new Workshop();

            List<IBunny> suitableBunnies = bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();

            if (suitableBunnies.Any() == false)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            while (suitableBunnies.Any())
            {
                IBunny currentBunny = suitableBunnies.First();

                while (true)
                {
                    if (currentBunny.Energy == 0 || currentBunny.Dyes.All(x => x.IsFinished()))
                    {
                        suitableBunnies.Remove(currentBunny);
                        break;
                    }

                    workshop.Color(egg, currentBunny);

                    if (egg.IsDone())
                    {
                        break;
                    }
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            return $"Egg {eggName} is {(egg.IsDone() ? "done" : "not done")}.";
            //List<IBunny> bestBunnies = bunnies.Models.Where(b => b.Energy >= 50).ToList();
            //bestBunnies.OrderByDescending(b => b.Energy).ThenByDescending(b => b.Dyes.Sum(d => d.Power));

            //if (bestBunnies.Count == 0)
            //{
            //    throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            //}

            //IEgg egg = eggs.FindByName(eggName);
            //IBunny bunny = bestBunnies[0];
            //Workshop workshop = new Workshop();

            //workshop.Color(egg, bunny);

            //if (bunny.Energy == 0)
            //{
            //    bunnies.Remove(bunny);
            //}

            //if (egg.IsDone())
            //{
            //    coloredEggsCount++;
            //    return string.Format(OutputMessages.EggIsDone);
            //}
            //else
            //{
            //    return string.Format(OutputMessages.EggIsNotDone);
            //}
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{eggs.Models.Count(x => x.IsDone())} eggs are done!");
            sb.AppendLine("Bunnies info:");

            List<IBunny> finalBunnies = bunnies.Models.ToList();

            foreach (var bunny in finalBunnies)
            {
                sb.AppendLine(bunny.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
