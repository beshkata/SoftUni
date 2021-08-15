namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        RobotManager robotManager;

        [SetUp]
        public void Setup()
        {
            robotManager = new RobotManager(5);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(-20)]
        public void Ctor_ThrowsIfCapacityIsLessThanZero(int capacity)
        {
            Assert.Throws<ArgumentException>(()=> robotManager = new RobotManager(capacity));
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]

        public void Capacity_ReturnRightValue(int capacity)
        {
            robotManager = new RobotManager(capacity);
            Assert.AreEqual(robotManager.Capacity, capacity);
        }

        [Test]

        public void Ctor_InitializeRobotList()
        {
            Assert.AreEqual(robotManager.Count, 0);
        }

        [Test]
        public void Add_ThrowsWhenRobotExist()
        {
            string name = "Robot";
            Robot robot = new Robot(name, 10);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot(name, 30)));
        }

        [Test]
        public void Add_ThrowsWhenCapacityExceeded()
        {
            for (int i = 0; i < 5; i++)
            {
                Robot robot = new Robot($"robot {i}", i + 1);
                robotManager.Add(robot);
            }

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Pesho", 50)));

        }

        [Test]

        public void Add_IncreaseCountWhenAdd()
        {
            int count = 4;
            for (int i = 0; i < 4; i++)
            {
                Robot robot = new Robot($"robot {i}", i + 1);
                robotManager.Add(robot);
            }

            Assert.AreEqual(robotManager.Count, count);
        }

        [Test]
        public void Remove_ThrowsWhenRobotDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("pesho"));
        }

        [Test]
        public void Remove_DecreaseCount()
        {
            int count = 4;
            for (int i = 0; i < 4; i++)
            {
                Robot robot = new Robot($"{i}", i + 1);
                robotManager.Add(robot);
            }
            robotManager.Remove("0");
            Assert.AreEqual(robotManager.Count, count - 1);
        }

        [Test]
        public void Work_ThrowsWhenRobotDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("pesho", "job", 10));
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        public void Work_ThrowsWhenBateryIsNotEnought(int batteryUsage)
        {
            string name = "Pesho";
            Robot robot = new Robot(name, 9);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work(name, "job", batteryUsage));
        }

        [Test]
        [TestCase(3)]
        [TestCase(4)]
        public void Work_DecreaseBattery(int batteryUsage)
        {
            string name = "Pesho";
            int battery = 9;
            Robot robot = new Robot(name, battery);
            robotManager.Add(robot);
            robotManager.Work(name, "job", batteryUsage);

            Assert.AreEqual(robot.Battery, battery - batteryUsage);
        }

        [Test]
        public void Charge_ThrowsWhenRobotDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Pesho"));
        }

        [Test]
        [TestCase(3)]
        [TestCase(4)]
        public void Charge_RechargeBattery(int batteryUsage)
        {
            string name = "Pesho";
            int battery = 9;
            Robot robot = new Robot(name, battery);
            robotManager.Add(robot);
            robotManager.Work(name, "job", batteryUsage);
            robotManager.Charge(name);

            Assert.AreEqual(robot.Battery, battery);
        }

    }
}
