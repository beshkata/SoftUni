using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private double health;
        private double armor;
        private Bag bag;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            BaseHealth = health;
            BaseArmor = armor;

            Name = name;
            Health = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;

        }

        public string Name
        {
			get => name;
			private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
				name = value;
            }
        }

		public double BaseHealth { get; protected set; }

		public double Health
        {
			get => health;
            set
            {
                if (value < 0)
                {
					value = 0;
                }

                if(value > BaseHealth)
                {
                    value = BaseHealth;
                }

                health = value;
            }
        }

        public double BaseArmor { get; protected set; }

        public double Armor
        {
            get => armor;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                armor = value;
            }
        }

        public double AbilityPoints { get; protected set; }

        public Bag Bag
        {
            get => bag;
            protected set
            {
                bag = value;
            }
        }
        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (Armor < hitPoints)
            {
                hitPoints -= Armor;
                Armor = 0;
                Health -= hitPoints;
                if (Health <= 0)
                {
                    IsAlive = false;
                }
            }
            else if (Armor >= hitPoints)
            {
                Armor -= hitPoints;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            //this.Bag.GetItem()
            item.AffectCharacter(this);
        }


        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}