using System;
using NUnit.Framework;
using Skeleton.Tests.Common;

namespace Skeleton.Tests
{

    [TestFixture]
    public class AxeTests
    {

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            this.axe = new Axe(TestValues.InitAxeAttackVal, TestValues.InitAxeDurabilityVal);
            this.dummy = new Dummy(TestValues.InitTestDummyHealth, TestValues.InitTestDummyExperience);
        }

        [Test]
        public void Test_WeaponLosesDurabilityWhenAttacking()
        {
            this.axe.Attack(this.dummy);
            Assert.That(this.axe.DurabilityPoints , Is.EqualTo(TestValues.AxeDurabilityCheckValue), "Axe durability doen't change after attack");
        }

        [Test]
        public void Test_AttackingWithBrokenWeaponShouldThrowExeption()
        {
            this.axe = new Axe(TestValues.BrokenAxeTestAttackVal, TestValues.BrokenAxeTestDurabilityVal);
            Assert.That(() =>
            {
                this.axe.Attack(this.dummy);
            }, Throws.Exception.TypeOf<InvalidOperationException>());
        }
    }
}
