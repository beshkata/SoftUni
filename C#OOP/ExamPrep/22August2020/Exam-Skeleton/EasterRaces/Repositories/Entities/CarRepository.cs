using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }
        public void Add(ICar model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return models.AsReadOnly();
        }

        public ICar GetByName(string name)
        {
            return models.FirstOrDefault(c => c.Model == name);
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }
    }
}
