using MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id,
            string firstName,
            string lastName,
            decimal salary,
            string corps,
            ICollection<IRepair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($"Corps: {Corps}");
            result.Append("Repairs:");
            if (Repairs.Count != 0)
            {
                result.AppendLine();
                int counter = 0;
                foreach (var repair in Repairs)
                {
                    if (counter == Repairs.Count - 1)
                    {
                        result.Append($"  {repair.ToString()}");
                    }
                    else
                    {
                        result.AppendLine($"  {repair.ToString()}");
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
