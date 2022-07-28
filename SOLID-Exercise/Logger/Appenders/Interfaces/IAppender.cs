using System;
using Logger.Messages.Interfaces;

namespace Logger.Appenders.Interfaces
{
    public interface IAppender
    {
        void Append(IMessage message);
    }
}

