using Logger.Enums;

namespace Logger.Loggers.Interfaces
{
    public interface IReportLevelThreshold
    {
        ReportLevel threshold { get; }
    }
}

