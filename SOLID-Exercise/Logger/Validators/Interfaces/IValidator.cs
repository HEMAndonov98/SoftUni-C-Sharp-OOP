using System;
namespace Logger.Validators.Interfaces
{
    internal interface IValidator
    {
        bool Validate(string dateTime);
    }
}

