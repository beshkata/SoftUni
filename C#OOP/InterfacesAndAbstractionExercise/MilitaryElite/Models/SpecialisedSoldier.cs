using System;

using MilitaryElite.Contracts;


namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps 
        {
            get =>this.corps;
            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException();
                }
                corps = value;
            }
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
