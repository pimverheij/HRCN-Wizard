using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaakService.MessageHandlers.CommandHandlers
{
    public interface ICommandHandler<TCommand>
    {
        Task HandleAsync(TCommand command);
    }
}
