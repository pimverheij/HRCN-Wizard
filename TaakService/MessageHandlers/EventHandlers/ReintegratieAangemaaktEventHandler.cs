using HRControlnet.Core.Eventbus.EventHandlers;
using HRControlnet.Core.Eventbus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaakService.Messages.Commands;
using TaakService.Messages.Events;

namespace TaakService.MessageHandlers.EventHandlers
{
    public class ReintegratieAangemaaktEventHandler : IEventHandler<ReintegratieAangemaaktEvent>
    {
        private readonly IMessageExecutor messageExecutor;

        public ReintegratieAangemaaktEventHandler(IMessageExecutor messageExecutor)
        {
            this.messageExecutor = messageExecutor;
        }

        public async Task HandleAsync(ReintegratieAangemaaktEvent @event)
        {
            var command = new MaakTaakAanCommand
            {
                HoortBijEntiteitId = @event.ReintegratieId,
                HoortBijEntiteitType = HRControlNet.Core.Data.Enums.EntiteitType.Reintegratie,
                Startdatum = DateTime.Today.AddDays(14),
                Type = HRControlNet.Core.Data.Enums.TaakType.ReintegratieTestTaak,
                Vervaldatum = DateTime.Today.AddDays(28),
                Taakomschrijving = "Dit is een re-integratie testtaak. Deze taak is gemaakt om een POC te kunnen maken van een wizard.",
            };

            await messageExecutor.ExecuteAsync(command);
        }
    }
}
