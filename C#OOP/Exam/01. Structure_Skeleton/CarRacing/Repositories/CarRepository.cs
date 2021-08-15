using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private Dictionary<string, ICar> carByVIN;

        public CarRepository()
        {
            carByVIN = new Dictionary<string, ICar>();
        }

        public IReadOnlyCollection<ICar> Models => carByVIN.Values.ToList();

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            carByVIN.Add(model.VIN, model);
        }

        public ICar FindBy(string property)
        {
            ICar car = null;

            if (carByVIN.ContainsKey(property))
            {
                car = carByVIN[property];
            }

            return car;
        }

        public bool Remove(ICar model)
        {
            return carByVIN.Remove(model.VIN);
        }
    }
}
