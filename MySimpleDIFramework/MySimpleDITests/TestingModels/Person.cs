using System;
namespace MySimpleDITests.TestingModels
{
    public class Person : IPerson
    {
        private IBrain brain;
        private ISoul soul;

        public Person(IBrain brain, ISoul isoul)
        {
            this.brain = brain;
            this.soul = isoul;
        }
        public IBrain Brain => this.brain;
        public ISoul Soul => this.soul;

    }
}

