using System;
using NUnit.Framework;
using Skeleton.Tests.Common;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {

        

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            this.axe = new Axe(TestValues.InitAxeAttackVal, TestValues.InitAxeDurabilityVal);
            this.dummy = new Dummy(TestValues.InitTestDummyHealth, TestValues.InitTestDummyExperience);
        }

        [Test]
        public void Test_DummyLoosesHealthWhenAttacked()
        {
            this.axe.Attack(this.dummy);
            Assert.That(this.dummy.Health, Is.EqualTo(TestValues.DummyHealthTestVal), "Dummy should lose health if attacked");
        }

        [Test]
        public void Test_DeadDummyThrowsExceptionIfAttacked()
        {
            this.dummy = new Dummy(TestValues.DeadDummyHealth, TestValues.DeadDummyExperience);
            Assert.That(() =>
            {
                this.dummy.TakeAttack(1);
            }, Throws.Exception.TypeOf<InvalidOperationException>(), "Cannot attack dead dummy");
        }

        [Test]
        public void Test_DeadDummyShouldGiveExperience()
        {
            this.dummy = new Dummy(TestValues.DeadDummyHealth, TestValues.DeadDummyExperience);
            int gainedExperience = this.dummy.GiveExperience();

            Assert.That(gainedExperience, Is.EqualTo(TestValues.DeadDummyExperience), "Dummy should give experience if Dead");
        }

        [Test]
        public void Test_LiveDummyGivingExperienceThrowsException()
        {
            this.dummy = new Dummy(TestValues.InitTestDummyHealth, TestValues.InitTestDummyExperience);

            Assert.That(() =>
            {
                this.dummy.GiveExperience();
            }, Throws.Exception.TypeOf<InvalidOperationException>(), "Dummy can't give experince when alive");
        }

    }
}

