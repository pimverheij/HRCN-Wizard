using HRControlnet.Core.Eventbus.EventHandlers;
using HRControlnet.Core.Eventbus.Events;
using System;

namespace HRControlnet.Core.Eventbus
{
    public interface IEventBus
    {
        void Publish(Event @event);

        void Subscribe<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>;

        void Unsubscribe<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>;
    }
}
