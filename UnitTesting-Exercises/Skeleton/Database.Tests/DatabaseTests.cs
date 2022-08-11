namespace Database.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database();
        }


        [TestCase(new int[0] )]
        [TestCase(new int[] {1, 2, 3, 4})]
        [TestCase(new int[] {1, 2 ,3 ,4 ,5 ,6 ,7 ,8})]
        [TestCase(new int[] {1, 2, 3, 4, 5 ,6, 7, 8, 9, 10, 11, 12, 13, 14 ,15, 16})]
        [Test]
        public void ConstructorShouldAddLassThan16Elements(int[] testArr)
        {
            var testDb = new Database(testArr);

            int[] actualData = testDb.Fetch();
            int[] expectedData = testArr;

            int actualCount = testDb.Count;
            int expectedCount = testArr.Length;

            Assert.AreEqual(expectedCount, actualCount, "Constructor should set correct count based on array given");
            CollectionAssert.AreEqual(expectedData, actualData, "Database should initialise data field correctly");
        }


        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20})]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [Test]
        public void ConstructorMustNotAllowMoreThan16Elements(int[] testArr)
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                var testDb = new Database(testArr);
            }, "Database Capacity should be 16 elements max");
        }

        [TestCase(new int[] {1})]
        [TestCase(new int[] {1, 2, 3, 4, 5 })]
        [TestCase(new int[] {1, 2, 3 ,4, 5, 6, 7, 8, 9, 10, 11, 12 ,13 ,14, 15, 16})]
        [Test]
        public void AddMethodShouldAddLessThan16Elements(int[] testArr)
        {

            for (int i = 0; i < testArr.Length; i++)
            {
                this.database.Add(testArr[i]);
            }

            var expectedData = testArr;
            var actualData = this.database.Fetch();

            var expectedCount = testArr.Length;
            var actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount, "Must have the same count as added elements");
            CollectionAssert.AreEqual(expectedData, actualData, "Must have the same elements as added elements");

        }

        [Test]
        public void AddingMoreThan16ElementsShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i <= 16; i++)
                {
                    this.database.Add(i);
                }
            }, "Cannot add more than 16 elements to the database");
        }


        [TestCase(new int[] {1, 2, 3})]
        [TestCase(new int[] {1})]
        [Test]
        public void RemoveOperationShouldRemoveLastElement(int[] elementsToREmove)
        {
            List<int> elementsToRemoveLi = new List<int>(elementsToREmove);

            for (int i = 0; i < elementsToRemoveLi.Count; i++)
            {
                this.database.Add(elementsToRemoveLi[i]);
            }

            this.database.Remove();
            elementsToRemoveLi.RemoveAt(elementsToRemoveLi.Count - 1);

            var actualData = this.database.Fetch();
            int[] expectedData = elementsToRemoveLi.ToArray();

            var actualCount = this.database.Count;
            var expectedCount = elementsToRemoveLi.Count;

            Assert.AreEqual(expectedCount, actualCount);
            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [Test]
        public void RemovingFromEmptyDatabaseThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            }, "Should not be able to remove from an empty database");
        }

        //The "Fetch()" method should return the elements as an array
        [TestCase(new int[] {1, 2, 3})]
        [TestCase(new int[] {1, 2 ,3 ,4 ,5})]
        [TestCase(new int[0])]
        [Test]
        public void FetchShouldReturnElementsAsCopy(int[] testData)
        {
            var testDb = new Database(testData);

            var expectedData = testData;
            var actualData = testDb.Fetch();

            var expectedCount = testData.Length;
            var actualCount = testDb.Count;

            var expectedType = typeof(int[]);
            var actualType = testDb.Fetch().GetType();


        }
    }
}
