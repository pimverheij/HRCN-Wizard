using System;
using System.Threading.Tasks;
using TaakService.MessageHandlers;
using TaakService.Messages.Commands;
using TaakService.Models;

namespace TaakService.Services
{
    public interface ITaakService
    {
        Task MaakTaakAan(MaakTaakAanCommand command);
        Task<TaakModel> ReadTaak(int id);
    }

    public class TaakService : ITaakService
    {
        private readonly IMessageExecutor commandExecutor;

        public TaakService(IMessageExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }

        public Task MaakTaakAan(MaakTaakAanCommand command)
        {
            return commandExecutor.ExecuteAsync(command);
        }

        public Task<TaakModel> ReadTaak(int id)
        {
            throw new NotImplementedException();
        }
    }
}
