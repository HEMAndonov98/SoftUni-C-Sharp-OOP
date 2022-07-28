using System;
using Logger.Enums;

namespace Logger.Messages.Interfaces
{
    public interface IMessage
    {
        string? MessageText { get; }
        string DateTime { get; }
        ReportLevel ReportLevel { get; }
    }
}

