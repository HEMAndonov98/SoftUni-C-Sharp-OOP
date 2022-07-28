using Logger.Messages.Interfaces;

namespace Logger.Formaters.Interfaces
{
    public interface IMessageFormater
    {
        string FormatMessage(IMessage message);
    }
}

