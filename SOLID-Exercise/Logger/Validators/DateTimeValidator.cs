using Logger.Validators.Interfaces;

namespace Logger.Validators
{
    internal class DateTimeValidator : IValidator
    {
        public bool Validate(string dateTime)
         =>  DateTime.TryParse(dateTime, out DateTime time);
    }
}

