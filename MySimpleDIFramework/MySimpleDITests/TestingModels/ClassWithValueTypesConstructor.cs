using System;
namespace MySimpleDITests.TestingModels
{
    public class ClassWithValueTypesConstructor
    {
        public string name;
        public int age;
        public bool isTrue;

        public ClassWithValueTypesConstructor(string name, int age, bool isTrue)
        {
            this.name = name;
            this.age = age;
            this.isTrue = isTrue;
        }

    }
}

