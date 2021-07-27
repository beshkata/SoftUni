using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Ctor_InitializeWarriorsCollection()
        {
            Assert.That(arena.Warriors, Is.Not.Null);
        }

        [Test]

        public void Enroll_AddWarrior()
        {
            Warrior warrior = new Warrior("Warrior", 10, 100);

            arena.Enroll(warrior);
            Assert.Contains(warrior, (System.Collections.ICollection)arena.Warriors);
        }

        [Test]
        public void Enroll_ThrowsWhenWarriorExist()
        {
            Warrior warrior = new Warrior("Warrior", 10, 100);

            arena.Enroll(warrior);

            Assert.That(() => arena.Enroll(warrior),
                Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));

        }

        [Test]
        public void Fight_ThrowsWhenAttackerNameIsInvalid()
        {
            string defenderName = "Defender";
            Warrior warrior = new Warrior(defenderName, 10, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", defenderName));
        }

        [Test]
        public void Fight_ThrowsWhenDefenderNameIsInvalid()
        {
            string attackerName = "Attacker";
            Warrior warrior = new Warrior(attackerName, 10, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, "Defender"));
        }

        [Test]
        public void Fight_ThrowsWhenBothNamesAreInvalid()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Attacker", "Defender"));
        }



    }
}
