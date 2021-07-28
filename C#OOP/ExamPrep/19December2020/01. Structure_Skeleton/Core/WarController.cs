using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		List<Character> party;
		Stack<Item> pool; //itemPool
		public WarController()
		{
			party = new List<Character>();
			pool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			Character character = null;

            if (characterType == nameof(Warrior))
            {
				character = new Warrior(name);
			}
            else if (characterType == nameof(Priest))
            {
				character = new Priest(name);
            }
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}

			party.Add(character);
			return string.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			Item item = null;
			string itemType = args[0];

            if (itemType == nameof(FirePotion))
            {
				item = new FirePotion();
            }
            else if (itemType == nameof(HealthPotion))
            {
				item = new HealthPotion();
            }
			else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemType));
			}

			pool.Push(item);
			return string.Format(SuccessMessages.AddItemToPool, itemType);
		}

		public string PickUpItem(string[] args)
		{
			string name = args[0];

			Character character = party.FirstOrDefault(c => c.Name == name);

            if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
            }

			if (pool.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
			string itemName = pool.Peek().GetType().Name;
			character.Bag.AddItem(pool.Pop());

			return string.Format(SuccessMessages.PickUpItem, name, itemName);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = party.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

			character.UseItem(character.Bag.GetItem(itemName));
			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();
			//sb.AppendLine(SuccessMessages.FinalStats);

            foreach (var character in party)
            {
				string charStatus = character.IsAlive ? "Alive" : "Dead";
				sb.AppendLine(string.Format(SuccessMessages.CharacterStats, character.Name, character.Health, character.BaseHealth,
					character.Armor, character.BaseArmor, charStatus));
            }
			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			StringBuilder sb = new StringBuilder();
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = party.FirstOrDefault(a => a.Name == attackerName);
            if (attacker == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

			Character receiver = party.FirstOrDefault(r => r.Name == receiverName);
            if (receiver == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

            if (attacker.GetType().Name != nameof(Warrior))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

			Warrior warrior = (Warrior)party.FirstOrDefault(a => a.Name == attackerName);
			warrior.Attack(receiver);

			sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName,
				receiverName, warrior.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth,
				receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
				sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string receiverName = args[1];

			Character healer = party.FirstOrDefault(h => h.Name == healerName);
            if (healer == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}

			Character receiver = party.FirstOrDefault(r => r.Name == receiverName);
			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

			if (healer.GetType().Name != nameof(Priest))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}

			Priest priest = (Priest)party.FirstOrDefault(h => h.Name == healerName);

			priest.Heal(receiver);

			return string.Format(SuccessMessages.HealCharacter, priest.Name, receiverName, priest.AbilityPoints,
				receiverName, receiver.Health);
		}
	}
}
