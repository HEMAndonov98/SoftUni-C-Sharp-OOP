using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main()
        {
            var person = new Person("Carl", "Jung", 30, 2000);
            person.IncreaseSalary(50);
        }
    }
}