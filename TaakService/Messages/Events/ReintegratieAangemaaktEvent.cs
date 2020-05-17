using HRControlnet.Core.Eventbus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaakService.Messages.Events
{
    public class ReintegratieAangemaaktEvent : Event
    {
        public int ReintegratieId { get; set; }
    }
}
