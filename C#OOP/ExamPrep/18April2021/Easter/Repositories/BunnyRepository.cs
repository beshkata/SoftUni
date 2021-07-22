using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private IDictionary<string, IBunny> bunniesByName;

        public BunnyRepository()
        {
            bunniesByName = new Dictionary<string, IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models
        {
            get => bunniesByName.Values.ToList().AsReadOnly();
        }

        public void Add(IBunny model)
        {
            bunniesByName.Add(model.Name, model);
        }

        public IBunny FindByName(string name)
        {
            IBunny bunny = null;
            if (bunniesByName.ContainsKey(name))
            {
                bunny = bunniesByName[name];
            }
            return bunny;
        }

        public bool Remove(IBunny model)
        {
            return bunniesByName.Remove(model.Name);
        }
    }
}
