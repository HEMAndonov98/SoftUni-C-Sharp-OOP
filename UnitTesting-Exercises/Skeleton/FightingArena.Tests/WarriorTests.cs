namespace FightingArena.Tests
{
    using System;
    using System.Reflection;
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
            var expectedName = "TestWarrior";
            var ExpectedDamage = 40;
            var ExpectedHp = 150;

            var testWarrior = new Warrior(expectedName, ExpectedDamage, ExpectedHp);

            string actualName = (string)this.GetField("name").GetValue(testWarrior);
            int actualDamage = (int)this.GetField("damage").GetValue(testWarrior);
            int actualHp = (int)this.GetField("hp").GetValue(testWarrior);

            Assert.AreEqual(expectedName, actualName, "Constructor sohuld set same name as provided");
            Assert.AreEqual(ExpectedDamage, actualDamage, "Constructor sohuld set same damage as provided");
            Assert.AreEqual(ExpectedHp, actualHp, "Constructor sohuld set same hp as provided");
        }

        private FieldInfo GetField(string fieldname)
            => typeof(Warrior).GetField(fieldname, BindingFlags.Instance | BindingFlags.NonPublic);



        //Tests for property getters

        [TestCase("jhon")]
        [TestCase("Peter")]
        [TestCase("Ray")]
        [Test]
        public void NameGetterShouldReturnValidName(string expectedName)
        {
            var testWarrior = new Warrior(expectedName, this.warrior.Damage, this.warrior.HP);
            var actualName = testWarrior.Name;

            Assert.AreEqual(expectedName, actualName, "Should return same Name as provided");
        }

        [TestCase(30)]
        [TestCase(60)]
        [TestCase(100)]
        [Test]
        public void DamageGetterShouldReturnValidDamage(int expectedDamage)
        {
            var testWarrior = new Warrior(this.warrior.Name, expectedDamage, this.warrior.HP);

            var actualDamage = testWarrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage, "Should return same Damage as provided");
        }

        [TestCase(50)]
        [TestCase(100)]
        [TestCase(200)]
        [Test]
        public void HpGetterShouldReturnValidHp(int expectedHp)
        {
            var testWarrior = new Warrior(this.warrior.Name, this.warrior.Damage, expectedHp);

            var actualHp = testWarrior.HP;

            Assert.AreEqual(expectedHp, actualHp, "Should return same Hp as provided");
        }


        //Tests for property validation setters

        [TestCase(null)]
        [TestCase("")]
        [Test]
        public void WarriorNameShouldThrowExeptionIfNullOrEmpty(string warriorName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(warriorName, this.warrior.Damage, this.warrior.HP);
            }, "Should not be able to set warrior name to null or empty string");
        }

        [Test]
        public void WarriorNameShouldThrowExceptionIfWhiteSpace()
        {
            string whiteSpaceForName = " ";

            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(whiteSpaceForName, this.warrior.Damage, this.warrior.HP);
            }, "Warrior name should throw expection if whitespace");
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

        [TestCase(120)]
        [TestCase(200)]
        [TestCase(300)]
        [Test]
        public void IfAttackerDamageIsMoreThanDefenderHealthShouldSetDefenderHpTo0(int attackerDamage)
        {
            var testWarrior = new Warrior(this.warrior.Name, attackerDamage, this.warrior.HP);
            testWarrior.Attack(this.warrior);

            var actualDefenderHp = this.warrior.HP;

            Assert.That(actualDefenderHp, Is.Zero);

        }

        [TestCase(10)]
        [TestCase(30)]
        [TestCase(29)]
        [Test]
        public void WarriorAttackShouldThrowExceptionIfAttackerHpIsLessThanOrEqualTo30(int warriorHp)
        {
            var testWarrior = new Warrior("Test", this.warrior.Damage, warriorHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testWarrior.Attack(this.warrior);
            }, "Should not be able to attack if hp is lower than or equal to 30");
        }

        [TestCase(10)]
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

        [TestCase(101)]
        [TestCase(110)]
        [TestCase(200)]
        [Test]
        public void AttackingStrongerFoeShouldThorwException(int defenderAttack)
        {
            var testWarrior = new Warrior("Attacker", defenderAttack, this.warrior.HP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.warrior.Attack(testWarrior);
            }, "Should not be able to attack if oponent is stronger(Has more damage than your health)");
        }
    }
}