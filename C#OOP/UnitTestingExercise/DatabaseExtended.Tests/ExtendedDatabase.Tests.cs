using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityExceeded()
        {
            
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, $"Username{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "username")), 
                "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Add_ThrowsException_WhenUsernameExists()
        {
            string username = "Name";

            database.Add(new Person(1, username));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(2, username)),
                "There is already user with this username!");
        }

        [Test]
        public void Add_ThrowsException_WhenIdExists()
        {
            long Id = 1;

            database.Add(new Person(Id, "name"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(Id, "user")),
                "There is already user with this Id!");
        }

        [Test]
        public void Add_IncreaseCount()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                database.Add(new Person(i, $"Username{i}"));
            }

            Assert.That(database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Add_InsertExactElement()
        {
            string name = "name";
            Person person = new Person(1, name);
            database.Add(person);

            Person personDb = database.FindByUsername(name);

            Assert.That(personDb, Is.EqualTo(person));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void FindByUsername_ThrowsIfArgumentIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name), "Username parameter is null!");
        }

        [Test]
        public void FindByUsername_ThrowsIfUsernameDoesNotExist()
        {
            database.Add(new Person(1, "name"));

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("user"),
                "No user is present by this username!");
        }

        [Test]
        public void FindByUsername_ReturnsRightElement()
        {
            string name = "name";
            Person person = new Person(1, name);
            database.Add(person);

            Person personDb = database.FindByUsername(name);

            Assert.That(personDb.UserName, Is.EqualTo(name));
        }

        [Test]
        public void Remove_ThrowsException_WhenCountIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_DecreaseCount()
        {
            database.Add(new Person(1, "name"));
            database.Add(new Person(2, "user"));

            database.Remove();

            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_RemovesElementFromDatabase()
        {
            database.Add(new Person(1, "name"));
            database.Add(new Person(2, "user"));

            database.Remove();

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("user"),
                "No user is present by this username!");
        }

        [Test]
        public void FindById_ThrowsIfArgumentIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-14),
                "Id should be a positive number!");
        }

        [Test]
        public void FindById_ThrowsWhenIdDoesNotExists()
        {
            database.Add(new Person(1, "name"));

            Assert.Throws<InvalidOperationException>(() => database.FindById(2), 
                "No user is present by this ID!");
        }

        [Test]
        public void Ctor_ThrowsWhenCapacityExceeded()
        {
            Person[] people = new Person[17];
            for (int i = 0; i < 17; i++)
            {
                people[i] = new Person(i, $"Username{i}");
            }

            Assert.Throws<ArgumentException>(() => database = new ExtendedDatabase.ExtendedDatabase(people),
                "Provided data length should be in range [0..16]!");
        }
    }
}