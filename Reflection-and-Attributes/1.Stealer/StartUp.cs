using System;
using System.Reflection;
using Stealer.Models;
using Stealer.Models.Contracts;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IVisualizer visualizer = new SpyVisualizer();
            ISpy spy = new Spy(visualizer);

            string hackerName = typeof(Hacker).FullName;

            spy.StealFieldInfo(hackerName , new string[] { "username", "password" });
            Console.WriteLine(spy.ShowData());
        }
    }
}

