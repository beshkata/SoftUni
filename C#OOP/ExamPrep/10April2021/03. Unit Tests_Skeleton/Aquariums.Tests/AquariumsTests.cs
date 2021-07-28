namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class AquariumsTests
    {
        Aquarium aquarium;
        string aquariumName = "Aquarium";
        int aquariumCapacity = 10;
        [SetUp]
        public void Setup()
        {
            aquarium = new Aquarium(aquariumName, aquariumCapacity);
        }

        [Test]
        public void FishCtor_SetsFields()
        {
            string name = "fish";

            Fish fish = new Fish(name);

            Assert.That(fish.Name, Is.EqualTo(name));
            Assert.IsTrue(fish.Available);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_ThrowsWhenNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(name, this.aquariumCapacity));                
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-13)]
        public void Ctor_ThrowsWhenCapacityIsNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium(this.aquariumName, capacity));
        }

        [Test]
        public void Ctor_SetsValidName()
        {
            Assert.That(aquarium.Name, Is.EqualTo(aquariumName));
        }

        [Test]
        public void Ctor_SetsValidCapacity()
        {
            Assert.That(aquarium.Capacity, Is.EqualTo(aquariumCapacity));
        }

        [Test]
        public void Ctor_InitializaFishCollection()
        {
            Assert.That(aquarium.Count, Is.Not.Null);
        }

        [Test]
        public void Add_AddsFish()
        {
            Fish fish = new Fish("fish");
            aquarium.Add(fish);
            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_ThrowsWhenCapacityIsExceeded()
        {
            for (int i = 0; i < aquariumCapacity; i++)
            {
                Fish fish = new Fish($"{i}");
                aquarium.Add(fish);
            }

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("fish")));
        }

        [Test]
        public void RemoveFish_ThrowsWhenFishDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("fish"));
        }

        [Test]
        public void RemoveFish_RemovesFishWhenFishExist()
        {
            string name = "fish";

            Fish fish = new Fish(name);
            aquarium.Add(fish);

            aquarium.RemoveFish(name);

            Assert.That(aquarium.Count, Is.EqualTo(0));
        }

        [Test]
        public void SellFish_ThrowsWhenFishDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("fish"));
        }

        [Test]
        public void SellFish_ReturnsRequestedFishAndFishAvailableIsFalse()
        {
            string name = "fish";
            Fish fish = new Fish(name);
            aquarium.Add(fish);

            Fish requestedFish = aquarium.SellFish(name);

            Assert.That(requestedFish, Is.EqualTo(fish));
            Assert.IsFalse(requestedFish.Available);
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void Report_ReturnsRightString(int n)
        {
            List<Fish> list = new List<Fish>();

            for (int i = 0; i < n; i++)
            {
                Fish fish = new Fish($"{i}");
                aquarium.Add(fish);
                list.Add(fish);

            }

            string fishNames = string.Join(", ", list.Select(f => f.Name));

            Assert.That(aquarium.Report(),
                Is.EqualTo(string.Format("Fish available at {0}: {1}", aquarium.Name, fishNames)));
        }
    }
}
