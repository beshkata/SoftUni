using Raiding.Models;

namespace Raiding.Factory
{
    public class PaladinFactory : HeroFactory
    {
        public PaladinFactory(string name)
            : base(name)
        {
        }

        public override Hero GetHero()
        {
            return new Paladin(Name);
        }
    }
}
