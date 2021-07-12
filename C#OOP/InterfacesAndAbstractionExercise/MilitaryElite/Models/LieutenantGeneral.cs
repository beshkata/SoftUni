using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id,
            string firstName,
            string lastName,
            decimal salary,
            ICollection<IPrivate> privates)
            :base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public ICollection<IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.Append("Privates:");
            if (Privates.Count != 0)
            {
                result.AppendLine();
                int counter = 0;
                foreach (Private private1 in Privates)
                {
                    if (counter == Privates.Count - 1)
                    {
                        result.Append($"  {private1.ToString()}");
                    }
                    else
                    {
                        result.AppendLine($"  {private1.ToString()}");
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
