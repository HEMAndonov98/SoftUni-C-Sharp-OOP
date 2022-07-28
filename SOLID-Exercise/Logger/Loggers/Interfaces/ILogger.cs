using Logger.Appenders.Interfaces;
using Logger.Enums;

namespace Logger.Loggers.Interfaces
{
    public interface ILogger
    {
        void Log(string time, string message, ReportLevel reportLevel);

        void AddAppender(IAppender appender);

        void RemoveAppender(IAppender appender);
    }
}

