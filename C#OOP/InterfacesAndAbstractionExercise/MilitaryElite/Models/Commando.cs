using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id,
            string firstName,
            string lastName,
            decimal salary,
            string corps,
            ICollection<IMission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }
        public ICollection<IMission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($"Corps: {Corps}");
            result.Append("Missions:");
            if (Missions.Count != 0)
            {
                result.AppendLine();
                int counter = 0;
                foreach (var mission in Missions)
                {
                    if (counter == Missions.Count - 1)
                    {
                        result.Append($"  {mission.ToString()}");
                    }
                    else
                    {
                        result.AppendLine($"  {mission.ToString()}");
                    }
                    counter++;
                }
            }
            //else
            //{
            //    result.AppendLine();
            //}
            return result.ToString().TrimEnd();

        }
    }
}
