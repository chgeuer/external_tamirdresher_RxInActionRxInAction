﻿namespace CreatingObservables.Chat
{
    using System;

    public class ChatConnection : IChatConnection
    {
        public event Action<string> Received = delegate { };
        public event Action Closed = delegate { };
        public event Action<Exception> Error = delegate { };

        public void NotifyRecieved(string msg)
        {
            Received(msg);
        }

        public void NotifyClosed()
        {
            Closed();
        }

        public void NotifyError()
        {
            Error(new OutOfMemoryException());
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnect");
        }
    }
}