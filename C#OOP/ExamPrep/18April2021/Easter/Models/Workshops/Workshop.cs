using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
            
        }
        public void Color(IEgg egg, IBunny bunny)
        {
            //while (bunny.Energy > 0 && bunny.Dyes.FirstOrDefault(d => d.Power > 0) != null && egg.IsDone() == false)
            //{
            //    bunny.Dyes.FirstOrDefault(d => d.Power > 0).Use();
            //    bunny.Work();
            //    egg.GetColored();
            //}

            while (!egg.IsDone())
            {
                if (bunny.Energy == 0)
                {
                    break;
                }

                if (bunny.Dyes.All(x => x.IsFinished()))
                {
                    break;
                }

                egg.GetColored();
                bunny.Work();
            }
        }
    }
}
