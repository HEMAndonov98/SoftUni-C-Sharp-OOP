using Logger.Enums;
using Logger.Exceptions;
using Logger.Messages.Interfaces;
using Logger.Validators;
using Logger.Validators.Interfaces;

namespace Logger.Messages
{
    public class Message : IMessage
    {
        private string dateTime = string.Empty;
        private readonly IValidator validator;


        public Message()
        {
            this.validator = new DateTimeValidator();
        }

        public Message(string  dateTime, ReportLevel reportLevel, string messageText)
            :this()
        {
            this.DateTime = dateTime;
            this.ReportLevel = reportLevel;
            this.MessageText = messageText;
        }

        public string DateTime
        {
            get { return dateTime; }
            private set
            {
                if (!this.validator.Validate(value))
                {
                    throw new InvalidDateTimeException();
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this.dateTime = value;
            }
                }

        public ReportLevel ReportLevel { get; private set; }

        public string? MessageText { get; private set; }
    }
}

