namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using System.Collections.Generic;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
            this.attacker = new Warrior("Atacker", 30, 100);
            this.defender = new Warrior("Defender", 30, 100);
        }

        [Test]
        public void ArenaConsturctorShouldInitialiseEmptyCollection()
        {
            var expectedCollection = new List<Warrior>();
            var actualCollection = this.arena.Warriors.ToList();

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void ArenaCollectionShouldBeEncapsulatedProperly()
        {
            var WarriorProperty = this.arena.GetType().GetProperty("Warriors");

            var expectedType = typeof(IReadOnlyCollection<Warrior>);
            var actualType = WarriorProperty.PropertyType;

            Assert.AreEqual(expectedType.Name, actualType.Name);

        }

        [Test]
        public void EnrollShoulEnrollValidWarriors()
        {
            List<Warrior> testWarriorLi = new List<Warrior>() { this.attacker, this.defender };

            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.defender);

            var expectedCount = testWarriorLi.Count;
            var actualCount = this.arena.Count;

            var expectedData = testWarriorLi;
            var actualData = this.arena.Warriors;

            Assert.AreEqual(expectedCount, actualCount, "Count should be the same as warriors enrolled to arena");
            CollectionAssert.AreEqual(expectedData, actualData, "Should enroll warriors in the same order and same count");
        }

        [Test]
        public void EnrollingSameWarriorTwiceShouldThrowException()
        {
            this.arena.Enroll(this.attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(this.attacker);
            }, "Should not be able to enroll the same warrior twice in the arena");
        }

        [Test]
        public void FightShouldWorkCorrtectlyWithValidValues()
        {
            var testAttacker = new Warrior("Atacker", 30, 100);
            var testDefender = new Warrior("Defender", 30, 100);

            this.arena.Enroll(testAttacker);
            this.arena.Enroll(testDefender);
            this.arena.Fight(testAttacker.Name, testDefender.Name);

            var expectedAttackerHP = this.attacker.HP - this.defender.Damage;
            var actualAttackerHP = this.arena.Warriors.First().HP;

            var expectedDefenderHp = this.defender.HP - this.attacker.Damage;
            var actualDefenderHp = this.arena.Warriors.Last().HP;

            Assert.AreEqual(expectedAttackerHP, actualAttackerHP);
            Assert.AreEqual(expectedDefenderHp, actualDefenderHp);
        }

        [Test]
        public void FightShouldThrowExceptionIfNoSuchDefenderWarriorEnrolled()
        {
            this.arena.Enroll(this.attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.defender.Name);
            }, "No such defender name in the arena, should throw exception");
        }

        [Test]
        public void FightShouldThrowExceptionIfNoShuchAttackerIsEnrolled()
        {
            this.arena.Enroll(this.defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.defender.Name);
            }, "No such atacker name in the arena, should throw exception");
        }
    }
}
