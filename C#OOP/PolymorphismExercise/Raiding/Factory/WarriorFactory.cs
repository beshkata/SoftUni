using Raiding.Models;

namespace Raiding.Factory
{
    public class WarriorFactory : HeroFactory
    {
        public WarriorFactory(string name)
            : base(name)
        {
        }

        public override Hero GetHero()
        {
            return new Warrior(Name);
        }
    }
}
