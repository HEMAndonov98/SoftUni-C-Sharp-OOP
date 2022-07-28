using Logger.Formaters.Interfaces;
using Logger.Layouts.Interfaces;
using Logger.Messages.Interfaces;

namespace Logger.Formaters
{
    public class MessageFormater : IMessageFormater
    {
        private readonly ILayout layout;

        public MessageFormater(ILayout layout)
        {
            this.layout = layout;
        }

        public string FormatMessage(IMessage message)
            => string.Format(this.layout.Format, message.DateTime, message.ReportLevel, message.MessageText);
    }
}

