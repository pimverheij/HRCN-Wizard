using HRControlnet.Core.Eventbus.RabbitMQ.Connections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRControlnet.Core.Eventbus.RabbitMQ.Extensions
{
    public static class StartupExtensions
    {
        public static void AddRabbitMQServiceBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRabbitMQConnectionManager, RabbitMQConnectionManager>();
            services.AddSingleton<IConnectionFactory>(connectionFactory => new ConnectionFactory
            {
                DispatchConsumersAsync = true,
                HostName = configuration["RabbitMQHostName"],
                UserName = configuration["RabbitMQUserName"],
                Password = configuration["RabbitMQPassword"]
            });
            services.AddSingleton<IEventBus, EventBusRabbitMQ>();
            services.AddSingleton<IEventbusSubscriptionManager, InMemoryEventbusSubscriptionManager>();
        }
    }
}
