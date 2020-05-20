using RabbitMQ.Client;
using System;
using System.IO;

namespace HRControlnet.Core.Eventbus.RabbitMQ.Connections
{
    public class RabbitMQConnectionManager : IRabbitMQConnectionManager
    {
        private IConnection connection;
        private bool disposed;
        private readonly IConnectionFactory connectionFactory;

        public bool IsConnected => connection != null && connection.IsOpen && !disposed;

        public RabbitMQConnectionManager(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IModel CreateModel()
        {
            if (!IsConnected)
                throw new InvalidOperationException("Can't create a model while RabbitMQ is not connected");
            return connection.CreateModel();
        }

        public void Dispose()
        {
            if (disposed) return;
            disposed = true;

            try
            {
                connection?.Dispose();
            }
            catch(IOException ex)
            {
                // Logging toevoegen
            }
        }

        public bool TryConnect()
        {
            connection = connectionFactory.CreateConnection();
            return IsConnected;
        }
    }
}
