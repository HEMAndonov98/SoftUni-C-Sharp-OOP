using Logger.Appenders.Interfaces;
using Logger.Formaters;
using Logger.Formaters.Interfaces;
using Logger.IO.Interfaces;
using Logger.Layouts.Interfaces;
using Logger.Messages.Interfaces;

namespace Logger.Appenders
{
    public class FileAppender : IAppender
    {
        private readonly ILayout layout;
        private readonly ILogFile logFile;
        private readonly IMessageFormater messageFormater;

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.layout = layout;
            this.logFile = logFile;
            this.messageFormater = new MessageFormater(this.layout);
        }

        public void Append(IMessage message)
        {
            this.logFile.Write(this.messageFormater.FormatMessage(message));
        }
    }
}

