using RabbitMQ.Client;
using System;

namespace CoreFrameWork.RabbitMQ
{
    public interface IRabbitMqPersistentConnection : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
