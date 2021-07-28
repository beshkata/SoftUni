using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double InitialAbilityPoints = 40;
        private const double baseHealt = 100;
        private const double baseArmor = 50;
        public Warrior(string name)
            : base(name, baseHealt, baseArmor, InitialAbilityPoints, new Satchel())
        {
            BaseHealth = baseHealt;
            BaseArmor = baseArmor;
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            if (this.Equals(character))
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(AbilityPoints);
        }
    }
}
