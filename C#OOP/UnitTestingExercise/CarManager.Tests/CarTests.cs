using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        Car car; 
        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Model", 10, 100);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Ctor_ThrowsWhenMakeIsNullOrEmpty(string make)
        {
            Assert.That(() => car = new Car(make, "model", 10, 100),
                Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Ctor_ThrowsWhenModelIsNullOrEmpty(string model)
        {
            Assert.That(() => car = new Car("make", model, 10, 100),
                Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-12)]
        public void Ctor_ThrowsWhenFuelConsumptionIsZeroOrNegative(double fuelConsumption)
        {
            Assert.That(() => car = new Car("make", "model", fuelConsumption, 100), 
                Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-14)]
        public void Ctor_ThrowsWhenFuelCapacityIsNegative(double fuelCapacity)
        {
            Assert.That(() => car = new Car("make", "model", 10, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }
        [Test]
        public void Ctor_SetsFields_WhenArgumentsAreValid()
        {
            Assert.That(car.Make, Is.EqualTo("Make"));
            Assert.That(car.Model, Is.EqualTo("Model"));
            Assert.That(car.FuelConsumption, Is.EqualTo(10));
            Assert.That(car.FuelCapacity, Is.EqualTo(100));
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-22)]
        public void Refuel_ThrowsWhenArgumentIsZeroOrNegative(double amount)
        {
            Assert.That(() => car.Refuel(amount),
                Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void Refuel_IncreasesFuelAmount()
        {
            double amount = 20;
            car.Refuel(amount);

            Assert.That(car.FuelAmount, Is.EqualTo(amount));
        }

        [Test]
        public void Refuel_WhenArgumentIsBiggerThanFuelCapacity()
        {
            car.Refuel(car.FuelCapacity * 1.20);

            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void Drive_ThrowsWhenFuelIsNotEnough()
        {
            Assert.That(() => car.Drive(100),
                Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]

        public void Drive_DecreasesFuelAmount_WhenArumentIsValid()
        {
            car.Refuel(car.FuelCapacity);

            car.Drive(100);

            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity - car.FuelConsumption));

        }

        [Test]
        public void Drive_DecreasesFuelAmountToZero_WhenDriveMaxDistance()
        {
            car.Refuel(car.FuelCapacity);
            car.Drive(car.FuelCapacity / car.FuelConsumption * 100);

            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

    }
}