﻿namespace Raiding.Models
{
    public class Druid : Hero
    {
        private const int DruidPower = 80;
        public Druid(string name)
            : base(name, DruidPower)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
