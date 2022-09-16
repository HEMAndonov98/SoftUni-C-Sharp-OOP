using System;
namespace MySimpleDITests.TestingModels
{
    public class Robot
    {
        
        public Robot(IBrain brain, Weapon weapon)
        {
            this.Brain = brain;
            this.Weapon = weapon;
        }

        public IBrain Brain { get; set; }
        public Weapon Weapon { get; set; }
    }
}

