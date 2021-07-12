using System;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        private string state;
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; private set; }

        public string State {
            get => this.state;
            private set 
            {
                if (value != "Finished" && value != "inProgress")
                {
                    throw new ArgumentException();
                }
                state = value;
            }
        }

        public void CompleteMission()
        {
            State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
