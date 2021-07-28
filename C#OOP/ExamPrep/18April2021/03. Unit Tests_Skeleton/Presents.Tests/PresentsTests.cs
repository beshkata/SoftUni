namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        Bag bag;
        [SetUp]
        public void Setup()
        {
            bag = new Bag();
        }
        [Test]
        public void PresentCtor_SetFieldValues()
        {
            string name = "Present";
            double magic = 2;

            Present present = new Present(name, magic);

            Assert.That(present.Name, Is.EqualTo(name));
            Assert.That(present.Magic, Is.EqualTo(magic));
        }

        [Test]
        public void BagCtor_InitializePresentsCollection()
        {
            Bag bag = new Bag();

            List<Present> list = bag.GetPresents().ToList();

            Assert.That(list, Is.Not.Null);
        }

        [Test]
        public void BagCreate_ThrowsWhenArgumentIsNull()
        {
            Present present = null;

            Assert.Throws<ArgumentNullException>(() => bag.Create(present));

        }

        [Test]
        public void BagCreate_ThrowsWhenPresentExist()
        {
            string name = "Present";
            double magic = 2;

            Present present = new Present(name, magic);
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void BagCreate_ReturnsRightString_WhenAddIsSucsessful()
        {
            string name = "Present";
            double magic = 2;

            Present present = new Present(name, magic);


            Assert.That(() => bag.Create(present), Is.EqualTo(string.Format("Successfully added present {0}.", name)));

        }

        [Test]
        public void BagCreate_AddPresent()
        {
            string name = "Present";
            double magic = 2;

            Present present = new Present(name, magic);
            bag.Create(present);

            List<Present> list = bag.GetPresents().ToList();

            Assert.Contains(present, list);

        }


        [Test]
        public void Remove_RemovesPresentFromPresentsAndReturnTrue()
        {
            string name = "Present";
            double magic = 2;

            Present present = new Present(name, magic);

            bag.Create(present);
            bool isRemoved = bag.Remove(present);
            List<Present> list = bag.GetPresents().ToList();


            Assert.That(list.Contains(present), Is.False);
            Assert.That(isRemoved, Is.True);
        }

        [Test]
        public void Remove_ReturnsFalseWhenPresentDoesNotExist()
        {
            string name = "Present";
            double magic = 2;

            Present present = new Present(name, magic);

            Assert.IsFalse(bag.Remove(present));
        }

        [Test]
        public void GetPresentWithLeastMagic_ReturnsRightPresent()
        {
            double smallestMagic = 1;

            Present present = new Present("present", smallestMagic);
            Present present1 = new Present("present1", 2);
            Present present2 = new Present("present2", 3);

            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);

            Present returnedPresent = bag.GetPresentWithLeastMagic();

            Assert.That(present, Is.EqualTo(returnedPresent));
        }

        [Test]
        public void GetPresent_ReturnsRightPresent()
        {
            string name = "present";

            Present present = new Present(name, 1);
            Present present1 = new Present("present1", 2);
            Present present2 = new Present("present2", 3);

            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);

            Present returnedPresent = bag.GetPresent(name);

            Assert.That(returnedPresent.Name, Is.EqualTo(name));
        }

        [Test]
        public void GetPresent_ReturnsNullWhenPresentDoesNotExist()
        {
            Present present = new Present("present", 1);
            Present present1 = new Present("present1", 2);
            Present present2 = new Present("present2", 3);

            bag.Create(present);
            bag.Create(present1);
            bag.Create(present2);

            Present returnedPresent = bag.GetPresent("NotExitingName");

            Assert.That(returnedPresent, Is.Null);
        }

        [Test]
        public void GetPresents_ReturnsRightCollection()
        {
            List<Present> presents = new List<Present>();

            for (int i = 0; i < 3; i++)
            {
                Present present = new Present($"Present{i}", i);
                presents.Add(present);
                bag.Create(present);
            }

            Assert.That(bag.GetPresents(), Is.EquivalentTo(presents));
        }


    }
}
