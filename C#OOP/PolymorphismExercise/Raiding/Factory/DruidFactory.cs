using Raiding.Models;

namespace Raiding.Factory
{
    public class DruidFactory : HeroFactory
    {
        public DruidFactory(string name)
            : base(name)
        {
        }

        public override Hero GetHero()
        {
            return new Druid(Name);
        }
    }
}
