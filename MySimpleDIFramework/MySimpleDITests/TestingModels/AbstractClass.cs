namespace MySimpleDITests.TestingModels
{
    public abstract class AbstractClass : ISomething
    {
        protected AbstractClass(string someString, int someInt)
        {
            this.SomeString = someString;
            this.SomeInt = someInt;
        }

        public string SomeString { get; set; }
        public int SomeInt { get; set; }
    }
}

