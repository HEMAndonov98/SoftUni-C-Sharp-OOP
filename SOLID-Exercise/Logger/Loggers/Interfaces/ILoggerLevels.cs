namespace Logger.Loggers.Interfaces
{
    public interface ILoggerLevels
    {
        void Info(string time, string message);

        void Warning(string time, string message);

        void Error(string time, string message);

        void Critical(string time, string message);

        void Fatal(string time, string message);
    }
}

