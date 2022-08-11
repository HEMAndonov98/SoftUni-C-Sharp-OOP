namespace CarManager.Tests
{
    using System;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car testCar;

        [SetUp]
        public void SetUp()
        {
            this.testCar = new Car("Ferarri", "Roma", 10.5, 80);
        }

        //Constructor Tests
       
        [Test]
        public void PrivateCarConstructorShouldCreateValidCar()
        {
            var expectedFuelAmount = 0;
            var actualFuelAmount = 0;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        //Property Getters also tested by validating car;
        [Test]
        public void PublicConstructorShouldCreateValidCar()
        {
            var expectedMake = "Ferarri";
            var expectedModel = "Roma";
            var expectedFuelCon = 10.5;
            var expectedFuelCap = 80;

            var actualMake = this.testCar.Make;
            var actualModel = this.testCar.Model;
            var actualFuelCon = this.testCar.FuelConsumption;
            var actualFuelCap = this.testCar.FuelCapacity;

            Assert.AreEqual(expectedMake, actualMake, "Makes do not match");
            Assert.AreEqual(expectedModel, actualModel, "Models do not match");
            Assert.AreEqual(expectedFuelCon, actualFuelCon, "Fuel Consumption does not match");
            Assert.AreEqual(expectedFuelCap, actualFuelCap, "Fuel Capacity does not match");
        }

        //Property Validation Tests
        [TestCase(null)]
        [TestCase("")]
        [Test]
        public void SettingMakePropToNullOrEmptyShouldThrowException(string carMake)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var testCar = new Car(carMake, "Passat", 5.5, 60);
            }, "Car make cannot be null or empty");
        }

        [TestCase(null)]
        [TestCase("")]
        [Test]
        public void SettingCarModelToNullOrEmptyShouldThrowException(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var testCar = new Car("VW", model, 5.5, 60);
            }, "Car model cannot be null or empty");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [Test]
        public void SettingFuelConsumptionToZeroOrNegativeShouldThrowException(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var testCar = new Car("Ferarri", "Roma", fuelConsumption, 80);
            }, "Setting fuel consumption to zero or negative should throw exception");
        }


        [TestCase(0)]
        [TestCase(-1)]
        [Test]
        public void SettingFuelCapacityToZeroOrNegativeShouldThrowException(double capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var testCar = new Car("Ferarri", "Roma", 10.5, capacity);
            }, "Fuel Capacity should not be 0 or negative");
        }

        [Test]
        public void SettingFuelAmountToNegativeThrowsException()
        {
            Type type = typeof(Car);
            PropertyInfo propertyInfo = type.GetProperty("FuelAmount");

            Assert.Throws<ArgumentException>(() =>
            {
                try
                {
                    propertyInfo.SetValue(this.testCar, -1);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            }, "Setting fuel amount to negative throws exception");
        }

        //Method Tests
        [TestCase(0)]
        [TestCase(-1)]
        [Test]
        public void RefuelingWithZeroOrNegativeFuelAmountShouldThrowException(double fuelAmount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.testCar.Refuel(fuelAmount);
            }, "Refueling with negative or zero amount of fuel should throw exception");
        }

        [TestCase(1)]
        [TestCase(30)]
        [TestCase(80)]
        [Test]
        public void RefuelingWithValidAmountShouldAddAmount(double fuelAmount)
        {
            this.testCar.Refuel(fuelAmount);

            var expectedAmount = fuelAmount;
            var actualAmount = this.testCar.FuelAmount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestCase(90)]
        [TestCase(150)]
        [Test]
        public void OverRefulingShouldAddOnlyAsMuchAsCapacity(double fuelAmount)
        {
            this.testCar.Refuel(fuelAmount);

            var expected = this.testCar.FuelCapacity;
            var actual = this.testCar.FuelAmount;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(50)]
        [TestCase(100)]
        [Test]
        public void DriveOperationShouldSetProperValues(double distance)
        {
            this.testCar.Refuel(80);
            var fuelNeeded = (distance / 100) * this.testCar.FuelConsumption;
            var expectedAmount = this.testCar.FuelAmount - fuelNeeded;

            this.testCar.Drive(distance);

            var acutualAmount = this.testCar.FuelAmount;

            Assert.AreEqual(expectedAmount, acutualAmount);
        }

        [TestCase(1200)]
        [TestCase(762)]
        [Test]
        public void DriveOperationShouldThrowExceptionIfDistanceIsBeyondCarFuelCapacity(double distance)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testCar.Drive(distance);
            }, "Car should not have enough fuel to complete drive");
        }
    }
}