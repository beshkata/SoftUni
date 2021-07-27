using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        Database.Database database;
        [SetUp]
        public void Setup()
        {
            database = new Database.Database(); 
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(16));
        }

        [Test]
        public void Add_CountIncreases()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            Assert.That(database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Add_InsertsRightElements()
        {
            int n = 5;
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                database.Add(i);
                numbers[i] = i;
            }

            Assert.That(database.Fetch(), Is.EquivalentTo(numbers));
        }

        [Test]
        public void Remove_ThrowsException_WhenCountIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_DecreasesCount()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            database.Remove();

            Assert.That(database.Count, Is.EqualTo(n - 1));
        }

        [Test]
        public void Remove_ExactElementIsRemoved()
        {
            int[] numbers = { 10 };
            database.Add(10);

            database.Remove();

            Assert.That(database.Fetch(), Is.Not.EquivalentTo(numbers));
        }

        [Test]
        public void Fetch_ReturnsCopyNotReference()
        {
            int n = 5;
            

            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            int[] numbers = database.Fetch();

            database.Add(5);

            Assert.That(database.Fetch(), Is.Not.EquivalentTo(numbers));
        }

        [Test]
        public void Ctor_AddsRightElementsToDatabase()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            Database.Database db = new Database.Database(numbers);

            Assert.That(db.Fetch(), Is.EquivalentTo(numbers));
        }
    }
}