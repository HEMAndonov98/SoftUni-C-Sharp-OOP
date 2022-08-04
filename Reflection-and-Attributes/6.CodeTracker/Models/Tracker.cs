using System;
using System.Linq;
using System.Reflection;
using AuthorProblem.CustomAttributes;

namespace AuthorProblem.Models.Interfaces
{
    public class Tracker : ITracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.Public |
                BindingFlags.NonPublic
                );
            foreach (MethodInfo method in methods
                .Where(m => m.CustomAttributes
                .Any(a => a.AttributeType == typeof(AuthorAttribute))))
            {
                var attributes = method.GetCustomAttributes(false);

                foreach (AuthorAttribute attr in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attr.Name}");
                }
            }
        }
    }
}

