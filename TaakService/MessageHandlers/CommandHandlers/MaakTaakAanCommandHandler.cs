using HRControlNet.Core.Data;
using HRControlNet.Core.Data.Repository;
using System.Threading.Tasks;
using TaakService.Messages.Commands;

namespace TaakService.MessageHandlers.CommandHandlers
{
    public class MaakTaakAanCommandHandler : ICommandHandler<MaakTaakAanCommand>
    {
        private readonly ITaakRepository repository;

        public MaakTaakAanCommandHandler(ITaakRepository repository)
        {
            this.repository = repository;
        }

        public Task HandleAsync(MaakTaakAanCommand command)
        {
            return repository.MaakTaakAanAsync(new Taak
            {
                HoortBijEntiteitId = command.HoortBijEntiteitId,
                HoortBijEntiteitType = command.HoortBijEntiteitType,
                Startdatum = command.Startdatum,
                Vervaldatum = command.Vervaldatum,
                Taakomschrijving = command.Taakomschrijving,
                Type = command.Type,
            });
        }
    }
}
