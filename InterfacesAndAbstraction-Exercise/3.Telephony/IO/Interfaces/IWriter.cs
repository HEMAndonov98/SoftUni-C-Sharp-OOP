using System;
namespace Telephony.IO.Interfaces
{
    public interface IWriter
    {
        public void WriteLine(string text);
        public void Write(string text);
    }
}

