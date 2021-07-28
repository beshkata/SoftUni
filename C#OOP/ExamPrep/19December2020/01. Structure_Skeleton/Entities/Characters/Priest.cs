using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double InitialAbilityPoints = 40;
        private const double baseHealt = 50;
        private const double baseArmor = 25;
        public Priest (string name)
            : base(name, baseHealt, baseArmor, InitialAbilityPoints, new Backpack())
        {
            BaseHealth = baseHealt;
            BaseArmor = baseArmor;
        }

        public void Heal(Character character)
        {
            this.EnsureAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            character.Health += this.AbilityPoints;
        }
    }
}
