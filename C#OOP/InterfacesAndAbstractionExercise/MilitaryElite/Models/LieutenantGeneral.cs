using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;
        public LieutenantGeneral(string id,
            string firstName,
            string lastName,
            decimal salary)
            : base(id, firstName, lastName, salary)
        {
            privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates
        {
            get { return this.privates.AsReadOnly(); }
            
        }

        public void AddPrivate(IPrivate @private)
        {
            privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine ( base.ToString());
            result.AppendLine("Privates:");

            foreach (var @private in Privates)
            {
                result.AppendLine($"  {@private.ToString()}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
