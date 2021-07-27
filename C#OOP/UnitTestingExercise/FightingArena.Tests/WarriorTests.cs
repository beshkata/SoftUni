using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        Warrior warrior; 
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Warrior", 20, 500);
        }

        [Test]
        [TestCase("  ")]
        [TestCase("")]
        [TestCase(null)]
        public void Ctor_ThrowsWhenNameIsNullOrWhiteSpace(string name)
        {
            Assert.That(() => warrior = new Warrior(name, 10, 100),
                Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-12)]
        [TestCase(-50)]
        public void Ctor_ThrowsWhenDamageIsZeroOrNegative(int damage)
        {
            Assert.That(() => warrior = new Warrior("Warrior", damage, 100),
                Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-20)]
        public void Ctor_ThrowsWhenHPIsNegative(int hp)
        {
            Assert.That(() => warrior = new Warrior("Warrior", 10, hp),
                Throws.ArgumentException.With.Message.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void Ctor_SetsFieldsWhenValuesAreValid()
        {
            string name = "Attacker";
            int damage = 10;
            int hp = 100;

            warrior = new Warrior(name, damage, hp);
            Assert.That(warrior.Name, Is.EqualTo(name));
            Assert.That(warrior.Damage, Is.EqualTo(damage));
            Assert.That(warrior.HP, Is.EqualTo(hp));
        }

        [Test]
        [TestCase(30)]
        [TestCase(29)]
        [TestCase(10)]
        public void Attack_ThrowsWhenAttackerHpAreLessOrEqualToMinHp(int hp)
        {
            Warrior attacker = new Warrior("Attacker", 10, hp);
            Warrior defender = new Warrior("Defender", 10, 100);

            Assert.That(() => attacker.Attack(defender),
                Throws.InvalidOperationException.With.Message.EqualTo
                ("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        [TestCase(30)]
        [TestCase(29)]
        [TestCase(10)]
        public void Attack_ThrowsWhenDefenderHpAreLessOrEqualToMinHp(int hp)
        {
            Warrior attacker = new Warrior("Attacker", 10, 100);
            Warrior defender = new Warrior("Defender", 10, hp);

            Assert.That(() => attacker.Attack(defender),
                Throws.InvalidOperationException.With.Message.EqualTo
                ("Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        [TestCase(40, 50)]
        [TestCase(40, 41)]
        public void Attack_ThrowsWhenDefenderDamageBiggerThanAttackerHp(int hp, int damage)
        {
            Warrior attacker = new Warrior("Attacker", 10, hp);
            Warrior defender = new Warrior("Defender", damage, 100);

            Assert.That(() => attacker.Attack(defender),
                Throws.InvalidOperationException.With.Message.EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void Attack_DecreaseAttackerHp()
        {
            int initialHp = 100;
            Warrior attacker = new Warrior("Attacker", 10, initialHp);
            Warrior defender = new Warrior("Defender", 20, initialHp);

            attacker.Attack(defender);

            Assert.That(attacker.HP, Is.EqualTo(initialHp - defender.Damage));
        }

        [Test]
        public void Attack_DecreaseDefenderHp()
        {
            int initialHp = 100;
            Warrior attacker = new Warrior("Attacker", 10, initialHp);
            Warrior defender = new Warrior("Defender", 20, initialHp);

            attacker.Attack(defender);

            Assert.That(defender.HP, Is.EqualTo(initialHp - attacker.Damage));
        }

        [Test]
        public void Attack_SetsDefenderHpToZero_WhenAttackerDamageIsBiggerThanDefenderHp()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior defender = new Warrior("Defender", 20, 40);

            attacker.Attack(defender);
            Assert.That(defender.HP, Is.EqualTo(0));
        }
    }
}