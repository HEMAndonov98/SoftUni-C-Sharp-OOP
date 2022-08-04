using System;
using AuthorProblem.CustomAttributes;
using AuthorProblem.Models.Interfaces;

namespace AuthorProblem
{
    public class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}

