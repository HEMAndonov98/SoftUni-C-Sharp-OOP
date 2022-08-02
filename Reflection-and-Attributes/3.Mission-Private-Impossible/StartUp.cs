using System;
using Stealer.Models;
using Stealer.Models.Contracts;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ISpy spy = new Spy();
            var fName = typeof(Hacker).FullName;
            Console.WriteLine(spy.RevealPrivateMethods(fName));
        }
    }
}

