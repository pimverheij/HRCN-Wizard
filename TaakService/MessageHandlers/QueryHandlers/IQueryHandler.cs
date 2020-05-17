using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaakService.Messages.Queries;

namespace TaakService.MessageHandlers.QueryHandlers
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
