using HRControlnet.Core.Eventbus.EventHandlers;
using HRControlnet.Core.Eventbus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRControlnet.Core.Eventbus
{
    public interface IEventbusSubscriptionManager
    {
        event EventHandler<string> OnEventRemoved;

        bool IsEmpty { get; }

        void Clear();

        string GetEventKey<TEvent>() where TEvent : Event;

        bool HasSubscriptionForEvent(string eventName);

        IEnumerable<Type> GetHandlersForEvent(string eventName);

        Type GetEventTypeByName(string eventName);

        void AddSubscription<TEvent, TEventHandler>()
                    where TEvent : Event
                    where TEventHandler : IEventHandler<TEvent>;

        void RemoveSubscription<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>;
    }
}
