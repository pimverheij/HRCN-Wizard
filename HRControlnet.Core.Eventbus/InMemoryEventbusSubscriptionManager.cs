using HRControlnet.Core.Eventbus.EventHandlers;
using HRControlnet.Core.Eventbus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace HRControlnet.Core.Eventbus
{
    public class InMemoryEventbusSubscriptionManager : IEventbusSubscriptionManager
    {
        private readonly Dictionary<string, List<Type>> handlers;
        private readonly List<Type> eventTypes;

        public bool IsEmpty => !handlers.Keys.Any();

        public event EventHandler<string> OnEventRemoved;

        public InMemoryEventbusSubscriptionManager()
        {
            this.handlers = new Dictionary<string, List<Type>>();
            this.eventTypes = new List<Type>();
        }

        public void AddSubscription<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>
        {
            var eventName = GetEventKey<TEvent>();
            var handlerType = typeof(TEventHandler);

            if (!HasSubscriptionForEvent(eventName))
                handlers.Add(eventName, new List<Type>());

            if(handlers[eventName].Any(type => type == handlerType))
                throw new InvalidOperationException($"Handler type '{handlerType.Name}' already registerd for '{eventName}'");

            handlers[eventName].Add(handlerType);

            if (!eventTypes.Contains(typeof(TEvent)))
                eventTypes.Add(typeof(TEvent));
        }

        public void RemoveSubscription<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>
        {
            var eventName = GetEventKey<TEvent>();
            var handlerToRemove = handlers[eventName].SingleOrDefault(type => type == typeof(TEventHandler));

            if(handlerToRemove != null)
            {
                handlers[eventName].Remove(handlerToRemove);

                if (!handlers[eventName].Any())
                {
                    handlers.Remove(eventName);
                    var eventType = eventTypes.SingleOrDefault(@event => @event.Name == eventName);
                    if (eventType != null)
                        eventTypes.Remove(eventType);

                    OnEventRemoved?.Invoke(this, eventName);
                }
            }
        }

        public bool HasSubscriptionForEvent(string eventName) => handlers.ContainsKey(eventName);

        public string GetEventKey<TEvent>() where TEvent : Event
        {
            return typeof(TEvent).Name;
        }

        public void Clear() => handlers.Clear();

        public IEnumerable<Type> GetHandlersForEvent(string eventName) => handlers[eventName];

        public Type GetEventTypeByName(string eventName) => eventTypes.SingleOrDefault(type => type.Name == eventName);
    }
}
