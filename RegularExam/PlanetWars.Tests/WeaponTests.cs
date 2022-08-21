using System;
using System.Reflection;
using NUnit.Framework;
using PlanetWars.Models.Weapons;

namespace PlanetWars.Tests
{
    public class WeaponTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [TestCase(1, "NuclearWeapon")]
        [TestCase(5)]
        [TestCase(10)]
        [Test]
        public void ConstructorCreatesInitialisesValidFields(int expectedDestructionLevel, string weaponType)
        {
            string fullyQualifiedName = $"PlanetWars.Models.Weapons.{weaponType}";

            Type t = (typeof(Weapon));
            var assembly = Assembly.GetAssembly(typeof(StartUp));

            Type weaponInstanceTpye = assembly.GetType(fullyQualifiedName);

            var weapon = Activator.CreateInstance(weaponInstanceTpye, expectedDestructionLevel);

            var actualDestructionLevel = t.GetField("destructionLevel", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(weapon);
            var actualPrice = t.GetField("price", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(weapon);

            Assert.AreEqual(expectedDestructionLevel, actualDestructionLevel);
            //Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        public void PriceGetterShouldReturnProperValue(int expectedPrice)
        {
            Weapon weapon = new NuclearWeapon(10);

            Type t = typeof(Weapon);

            t.GetProperty("Price");
        }
    }
}

