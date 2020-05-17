using HRControlnet.Core.Eventbus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaakService.MessageHandlers.EventHandlers;
using TaakService.Messages.Events;

namespace TaakService
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureServiceBus(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<ReintegratieAangemaaktEvent, ReintegratieAangemaaktEventHandler>();
        }
    }
}
