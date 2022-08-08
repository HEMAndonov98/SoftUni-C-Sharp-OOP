using System;
namespace CommandPattern.IO.Contracts
{
    public interface IWriter
    {
        void Write(string input);

        void WriteLine(string input);
    }
}

