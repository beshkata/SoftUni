using MilitaryElite.Contracts;
using System.Text;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            //Name: <firstName> <lastName> Id: <id>
            //Code Number: <codeNumber>

            StringBuilder result = new StringBuilder();
            result.AppendLine($"Name: {FirstName} {LastName} Id: <id>");
            result.Append($"Code Number: {CodeNumber}");

            return result.ToString().TrimEnd();
        }
    }
}
