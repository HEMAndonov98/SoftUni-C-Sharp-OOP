using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        //Made the class work with abstraction

        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            //method doesent have to check what type of IEmployee the entity is
            //every class of type IEmployee is responsible for how its details will be printed
            //the method only calls for the printing not the format
            foreach (IEmployee employee in this.employees)
            {
                this.PrintEmployee(employee);
            }
        }

        private void PrintEmployee(IEmployee employee)
        {
            Console.WriteLine(employee);
        }
    }
}
