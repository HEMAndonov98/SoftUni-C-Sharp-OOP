using System;
using Stealer.Models;
using Stealer.Models.Contracts;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string fName = typeof(Hacker).FullName;
            var spy = new Spy();
            Console.WriteLine(spy.AnalyzeAccessModifiers(fName));
        }
    }
}

