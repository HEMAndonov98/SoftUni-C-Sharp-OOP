using System;
using System.Collections.Generic;
using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<IEmployee> employees = new List<IEmployee>();
            string[] docs = { "pete", "maria", "timothy" };
            Manager manager = new Manager("jake", docs);
            employees.Add(manager);
            Employee employee = new Employee("taning");
            employees.Add(employee);
            CEO ceo = new CEO("the Boos");
            ceo.IsBoss = true;
            employees.Add(ceo);

            var detailPrinter = new DetailsPrinter(employees);
            detailPrinter.PrintDetails();
        }
    }
}
