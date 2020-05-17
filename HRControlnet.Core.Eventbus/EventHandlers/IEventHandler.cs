using HRControlnet.Core.Eventbus.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRControlnet.Core.Eventbus.EventHandlers
{
    public interface IEventHandler<in TEvent> where TEvent : Event
    {
        Task HandleAsync(TEvent @event);
    }
}
