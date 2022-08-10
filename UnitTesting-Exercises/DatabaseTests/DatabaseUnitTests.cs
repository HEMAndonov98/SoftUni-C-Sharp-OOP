using NUnit.Framework;
using DatabaseProject;
using System;
using System.Reflection;

namespace DatabaseTests
{
    public class Tests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database();
        }

        [Test]
        public void Test_DatabaseCapacityShouldBe16()
        {
            Assert.That(() =>
            {
                this.database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);
            }, Throws.Exception.TypeOf<InvalidOperationException>(), "Capacity should be 16");
        }

        [Test]
        public void Test_AddOperationShouldAddElementAtTheNextFreeCell()
        {
            this.database = new Database(1, 2, 3);
            this.database.Add(4);
            var expected = new int[] { 1, 2, 3, 4 };

            CollectionAssert.AreEqual(expected, this.database.Fetch());
        }

        [Test]
        public void Test_AddingMoreThan16ElementsThrowsException()
        {
            this.database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.That(() =>
            {
                this.database.Add(17);
            }, Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Test_RemoveMethodShouldRemoveOnlyLastElement()
        {
            this.database = new Database(1, 2, 3, 4, 5);
            this.database.Remove();
            var expected = new int[] { 1, 2, 3, 4 };

            CollectionAssert.AreEqual(expected, this.database.Fetch());
        }

        [Test]
        public void Test_RemovingFromEmptyDatabaseShouldThrowException()
        {
            this.database = new Database();

            Assert.That(() =>
            {
                this.database.Remove();
            }, Throws.Exception.TypeOf<InvalidOperationException>(), "Should not be able to remove from empty Database");
        }

        [Test]
        public void Test_DatabaseConstructorsShouldOnlyAcceptIntegers()
        {
            Type type = typeof(Database);
            Type[] parameterType = new Type[] { typeof(int[]) };
            ConstructorInfo constructor = type.GetConstructor(parameterType);
            ParameterInfo[] constructorArguments = constructor.GetParameters();

            Assert.AreEqual(typeof(int[]), constructorArguments[0].ParameterType);
        }

    }
}
//Storing array's capacity must be exactly 16 integer
//o If the size of the array is not 16 integers long, InvalidOperationException is thrown -- done


//· The "Add()" operation, should add an element at the next free cell (just like a stack) -- done
//o If there are 16 elements in the Database and try to add 17th, InvalidOperationException is thrown - done

//· The "Remove()" operation, should support only removing an element at the last index (just like a stack) - done

//o If you try to remove an element from an empty Database, InvalidOperationException is thrown -- done

//· Constructors should take integers only, and store them in the array

//· The "Fetch()" method should return the elements as an array