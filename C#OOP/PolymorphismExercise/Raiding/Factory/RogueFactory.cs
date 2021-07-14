using Raiding.Models;

namespace Raiding.Factory
{
    public class RogueFactory : HeroFactory
    {
        public RogueFactory(string name)
            : base(name)
        {
        }

        public override Hero GetHero()
        {
            return new Rogue(Name);
        }
    }
}
