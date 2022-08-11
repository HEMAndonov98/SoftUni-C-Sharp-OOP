namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using ExtendedDatabase;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using NUnit.Compatibility;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;
        private Person person;

        [SetUp]
        public void SetUp()
        {
            this.db = new Database();
            this.person = new Person(123, "Jhon");
        }

        [Test]
        public void Constructor_ShouldThrowException_IfAddingMoreThan16People()
        {
            Person[] people = new Person[17];

            Assert.Throws<ArgumentException>(() =>
            {
                this.db = new Database(people);
            }, "Should not be able to construct database with more than 16 people");
        }

        [Test]
        public void Add_ShouldAddValidPerson()
        {
            this.db.Add(this.person);

            var expected = this.person;
            var actual = this.db.FindById(123);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Adding_UserWithExistingUsername_ShouldThrowException()
        {
            var duplicatePerson = new Person(1234, "Jhon");

            this.db.Add(this.person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(duplicatePerson);
            }, "Cannot add two people with duplication usernames");
        }

        [Test]
        public void Adding_UserWithExistingId_ShouldThrowException()
        {
            var duplicatePerson = new Person(123, "Pesho");

            this.db.Add(this.person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(duplicatePerson);
            }, "Cannot add two people with duplicating ids");
        }

        [Test]
        public void Adding_MoreThan16People_ShouldThrowExpection()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 17; i++)
                {
                    var person = new Person(i, i.ToString());
                    this.db.Add(person);
                }
            }, "Should not be able to add more than 16 people");
        }



        [Test]
        public void Remove_ShouldRemoveLastPerson()
        {
            var testPerson1 = new Person(0001, "Hristo");
            var testPerson2 = new Person(0002, "Asya");
            var testPerson3 = new Person(0003, "George");

            var testList = new List<Person>() {testPerson1, testPerson2, testPerson3 };
            var testDb = new Database(testPerson1, testPerson2, testPerson3);

            testList.RemoveAt(testList.Count - 1);
            testDb.Remove();

            var expectedCount = testList.Count;
            var actualCount = testDb.Count;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testDb.FindById(0003);
            }, "Last Person has not been removed from the databse");
        }

        [Test]
        public void RemovingPerson_FromAnEmplyDatabase_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Remove();
            }, "Should not be able to remove from empty database");
        }



        [Test]
        public void FindByUsername_ShouldReturnValidPerson()
        {
            this.db.Add(this.person);

            var expected = this.person;
            var actual = this.db.FindByUsername("Jhon");


            Assert.AreEqual(expected, actual);
        }

        [TestCase("InvalidUsername")]
        [TestCase("jhon")]
        [Test]
        public void FindByUsernameOperation_WithNonExistentUsername_ShouldThrowException(string parameter)
        {
            this.db.Add(this.person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.FindByUsername(parameter);
            }, "Searching for an non existent username in the database should throw exception");
        }

        [TestCase(null)]
        [TestCase("")]
        [Test]
        public void FindByUsernameOperation_WithNullOrEmptyParameter_SouldThrowException(string parameter)
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.db.FindByUsername(parameter);
            }, "Searching with an empty or null parameter should throw exception");
        }


        [Test]
        public void FindById_ShouldReturnValidPerson()
        {
            this.db.Add(this.person);

            var expected = this.person;
            var actual = this.db.FindById(123);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1234)]
        [TestCase(12345)]
        [TestCase(12)]
        [Test]
        public void FindById_WithNonExistentId_ShouldThrowException(long idParam)
        {
            this.db.Add(this.person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.FindById(idParam);
            }, "Searching by id with an invalid(non existent) id should throw exception");
        }

        [Test]
        public void FindById_WithNegativeId_ShouldThrowException()
        {
            long negativeId = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.db.FindById(negativeId);
            }, "Searching by id with a negative id value should throw expection");
        }
    }
}