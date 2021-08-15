using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private Dictionary<string, IRacer> racerByUsername;

        public RacerRepository()
        {
            racerByUsername = new Dictionary<string, IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => racerByUsername.Values.ToList();

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            racerByUsername.Add(model.Username, model);
        }

        public IRacer FindBy(string property)
        {
            IRacer racer = null;

            if (racerByUsername.ContainsKey(property))
            {
                racer = racerByUsername[property];
            }

            return racer;
        }

        public bool Remove(IRacer model)
        {
            return racerByUsername.Remove(model.Username);
        }
    }
}
