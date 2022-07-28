using Logger.Appenders.Interfaces;
using Logger.Formaters;
using Logger.Formaters.Interfaces;
using Logger.Layouts.Interfaces;
using Logger.Messages.Interfaces;

namespace Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private readonly IMessageFormater messageFormater;
        private readonly ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
            this.messageFormater = new MessageFormater(this.layout);
        }

        public void Append(IMessage message)
        {
            Console.WriteLine(this.messageFormater.FormatMessage(message));
        }
    }
}

