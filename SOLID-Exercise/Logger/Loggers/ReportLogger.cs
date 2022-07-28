using Logger.Appenders.Interfaces;
using Logger.Enums;
using Logger.Loggers.Interfaces;
using Logger.Messages;
using Logger.Messages.Interfaces;

namespace Logger.Loggers
{
    public class ReportLogger : ILogger, ILoggerLevels, IReportLevelThreshold
    {
        private readonly IList<IAppender> appenders;

        public ReportLevel threshold { get; private set; } = ReportLevel.Info;

        public ReportLogger(ReportLevel threshold ,params IAppender[] appenders)
        {
            this.appenders = appenders;
            this.threshold = threshold;
        }



        public void Info(string time, string message)
        {
            this.Log(time, message, ReportLevel.Info);
        }

        public void Warning(string time, string message)
        {
            this.Log(time, message, ReportLevel.Warning);
        }

        public void Error(string time, string message)
        {
            this.Log(time, message, ReportLevel.Error);
        }

        public void Critical(string time, string message)
        {
            this.Log(time, message, ReportLevel.Critical);
        }

        public void Fatal(string time, string message)
        {
            this.Log(time, message, ReportLevel.Fatal);
        }



        public void Log(string time, string text, ReportLevel reportLevel)
        {
            IMessage message = new Message(time, reportLevel, text);
            foreach (var appender in this.appenders)
            {
                if (this.threshold <= reportLevel)
                {
                    appender.Append(message);
                }
            }
        }



        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }
        public void RemoveAppender(IAppender appender)
        {
            this.appenders.Remove(appender);
        }

    }
}

