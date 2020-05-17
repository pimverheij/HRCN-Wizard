using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRControlnet.Core.Eventbus.RabbitMQ.Connections
{
    public interface IRabbitMQConnectionManager : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
