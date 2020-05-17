using HRControlnet.Core.Eventbus.EventHandlers;
using HRControlnet.Core.Eventbus.Events;
using HRControlnet.Core.Eventbus.RabbitMQ.Connections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Framing.Impl;
using System;
using System.Collections;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HRControlnet.Core.Eventbus.RabbitMQ
{
    public class EventBusRabbitMQ : IEventBus, IDisposable
    {
        private const string BROKER_NAME = "hrcn_event_bus";
        private string queueName;
        private readonly IEventbusSubscriptionManager subscriptionManager;
        private readonly IRabbitMQConnectionManager connectionManager;
        private readonly IServiceProvider serviceProvider;
        private IModel consumerChannel;

        public EventBusRabbitMQ(IEventbusSubscriptionManager eventbusSubscriptionManager, IRabbitMQConnectionManager connectionManager, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            queueName = configuration["QueueName"];
            subscriptionManager = eventbusSubscriptionManager;
            this.connectionManager = connectionManager;
            this.serviceProvider = serviceProvider;
            consumerChannel = CreateConsumerChannel();
            eventbusSubscriptionManager.OnEventRemoved += EventbusSubscriptionManager_OnEventRemoved;
        }

        private void EventbusSubscriptionManager_OnEventRemoved(object sender, string eventName)
        {
            if (!connectionManager.IsConnected)
                connectionManager.TryConnect();

            using (var channel = connectionManager.CreateModel())
            {
                channel.QueueUnbind(queue: queueName, exchange: BROKER_NAME, routingKey: eventName);

                if (subscriptionManager.IsEmpty)
                {
                    queueName = string.Empty;
                    consumerChannel.Close();
                }
            }
        }

        public void Publish(Event @event)
        {
            throw new NotImplementedException();
        }

        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>
        {
            var eventName = subscriptionManager.GetEventKey<TEvent>();
            SubscribeToRabbitMQEventBus(eventName);
            subscriptionManager.AddSubscription<TEvent, TEventHandler>();
            StartConsuming();
        }

        public void Unsubscribe<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>
        {
            throw new NotImplementedException();
        }

        private void SubscribeToRabbitMQEventBus(string eventName)
        {
            if (!subscriptionManager.HasSubscriptionForEvent(eventName))
            {
                if (!connectionManager.IsConnected)
                    connectionManager.TryConnect();

                using (var channel = connectionManager.CreateModel())
                    channel.QueueBind(queue: queueName, exchange: BROKER_NAME, routingKey: eventName);
            }
        }

        private IModel CreateConsumerChannel()
        {
            if (!connectionManager.IsConnected)
                connectionManager.TryConnect();

            var channel = connectionManager.CreateModel();

            channel.ExchangeDeclare(exchange: BROKER_NAME, type: "direct");
            channel.QueueDeclare(queue: queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            return channel;
        }

        private void StartConsuming()
        {
            //var consumer = new EventingBasicConsumer(consumerChannel);
            var consumer = new AsyncEventingBasicConsumer(consumerChannel);
            consumer.Received += Consumer_Received; ;
            consumerChannel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs eventArgs)
        {
            var eventName = eventArgs.RoutingKey;
            var message = Encoding.UTF8.GetString(eventArgs.Body);

            try
            {
                await ProcessEvent(eventName, message);
                consumerChannel.BasicAck(eventArgs.DeliveryTag, multiple: false);
            }
            catch (Exception ex)
            {
                //Logging toevoegen
            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (subscriptionManager.HasSubscriptionForEvent(eventName))
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var handlerTypes = subscriptionManager.GetHandlersForEvent(eventName);
                    foreach (var handlerType in handlerTypes)
                    {
                        dynamic handler = scope.ServiceProvider.GetService(handlerType);
                        var eventType = subscriptionManager.GetEventTypeByName(eventName);
                        var @event = JsonConvert.DeserializeObject(message, eventType);

                        await Task.Yield();
                        await handler.HandleAsync((dynamic)@event);
                    }
                }
            }
        }


        public void Dispose()
        {
            subscriptionManager.Clear();
            consumerChannel?.Dispose();
            connectionManager?.Dispose();
        }
    }
}
