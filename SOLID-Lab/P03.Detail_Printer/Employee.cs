using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    //When creating a new type of employee the only thing it need to do is eiter inherit from this base class
    //or implement the IEmployee interface -> see CEO class
    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
