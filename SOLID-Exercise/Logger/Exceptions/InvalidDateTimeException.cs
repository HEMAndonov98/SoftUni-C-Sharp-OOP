using System.Runtime.CompilerServices;

namespace Logger.Exceptions
{
    public class InvalidDateTimeException : Exception
    {
        private const string DefaultMessage = "the date-time provided was invalid, did you pass in something else?";
        public InvalidDateTimeException()
            :base(DefaultMessage)
        {
        }
    }
}

