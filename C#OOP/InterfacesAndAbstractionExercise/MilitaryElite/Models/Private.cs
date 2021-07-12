using MilitaryElite.Contracts;
using System;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary)
            :base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
        //Name: < firstName > < lastName > Id: < id > Salary: < salary >
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Math.Round(Salary, 2):f2}";
        }
    }
}
