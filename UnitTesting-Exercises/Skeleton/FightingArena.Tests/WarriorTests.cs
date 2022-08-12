namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            this.warrior = new Warrior("Chris", 30, 100);
        }

        //Tests for constructor and property getters

        [Test]
        public void ConstructorShouldCreateValidWarrior()
        {
            var expectedName = "Chris";
            var actualName = this.warrior.Name;

            var expectedDamage = 30;
            var actualDamage = this.warrior.Damage;

            var expectedHp = 100;
            var actualHp = this.warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHp, actualHp);
        }


        //Tests for property validation setters

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [Test]
        public void WarriorNameShouldThrowExeptionIfNullOrWhitespace(string warriorName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(warriorName, this.warrior.Damage, this.warrior.HP);
            }, "Should not be able to set warrior name to null, empty or whitespace string");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [Test]
        public void WarriorDamegeShouldThrowExepctionIfZeroOrNegative(int warriorDamage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(this.warrior.Name, warriorDamage, this.warrior.HP);
            }, "Should not be able to set warrior damage to zero or negative value");
        }

        [Test]
        public void WarriorHPShouldThrowExpectionIfNegative()
        {
            var warriorHp = -1;

            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(this.warrior.Name, this.warrior.Damage, warriorHp);
            }, "Should not be able to set warrior hp to negative value");
        }


        //Tests for Attack method

        [Test]
        public void WarriorShouldAttackSuccesfullyIfValidValues()
        {
            var defenderWarrrior = new Warrior("Defender", 30, 100);

            this.warrior.Attack(defenderWarrrior);

            var expectedAttackerHp = 70;
            var actualAttackerHp = this.warrior.HP;

            var expectedDefenderHp = 70;
            var actualDefenderHp = defenderWarrrior.HP;



            Assert.AreEqual(expectedAttackerHp, actualAttackerHp);
            Assert.AreEqual(expectedDefenderHp, actualDefenderHp);
        }

        [TestCase(30)]
        [TestCase(29)]
        [Test]
        public void WarriorAttackShouldThrowExceptionIfHisHpIsLessThanOrEqualTo30(int warriorHp)
        {
            var testWarrior = new Warrior("Test", this.warrior.Damage, warriorHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testWarrior.Attack(this.warrior);
            }, "Should not be able to attack if hp is lower than or equal to 30");
        }

        [TestCase(30)]
        [TestCase(29)]
        [Test]
        public void WarriorAttackShouldThrowExeptionIfDefenderWarriorHpIsLowerThanOrEqualTo30(int defenderHp)
        {
            var testDefenderWarrior = new Warrior("Defender", this.warrior.Damage, defenderHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.warrior.Attack(testDefenderWarrior);
            }, "Should not be able to attack if defender hp is lower than or equal to 30");
        }

        [TestCase(29)]
        [TestCase(10)]
        [TestCase(0)]
        [Test]
        public void AttackingStrongerFoeShouldThorwException(int warriorHp)
        {
            var testWarrior = new Warrior("Attacker", this.warrior.Damage, warriorHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testWarrior.Attack(this.warrior);
            }, "Should not be able to attack if oponent is stronger(Has more damage than your health)");
        }
    }
}