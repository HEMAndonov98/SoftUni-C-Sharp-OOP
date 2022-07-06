using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var myStack = new StackOfStrings();
            var names = new string[] { "Pesho", "Gosho", "Mihaela", "Martin" };
            myStack.Push("Elena");
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.IsEmpty());
            myStack.AddRange(names);
            Console.WriteLine(myStack.Peek());
        }
    }
}

