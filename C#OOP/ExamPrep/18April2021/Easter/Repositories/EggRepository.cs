using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private IDictionary<string, IEgg> eggsByName;

        public EggRepository()
        {
            eggsByName = new Dictionary<string, IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models
        {
            get => eggsByName.Values.ToList().AsReadOnly();
        }

        public void Add(IEgg model)
        {
            eggsByName.Add(model.Name, model);
        }

        public IEgg FindByName(string name)
        {
            IEgg egg = null;
            if (eggsByName.ContainsKey(name))
            {
                egg = eggsByName[name];
            }
            return egg;
        }

        public bool Remove(IEgg model)
        {
            return eggsByName.Remove(model.Name);
        }
    }
}
