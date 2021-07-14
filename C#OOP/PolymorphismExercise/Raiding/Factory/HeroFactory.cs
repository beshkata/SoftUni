using Raiding.Models;

namespace Raiding.Factory
{
    public abstract class HeroFactory
    {
        
        public HeroFactory(string name)
        {
            Name = name;
        }
        public string Name { get;  }
        public abstract Hero GetHero();
    }
}
