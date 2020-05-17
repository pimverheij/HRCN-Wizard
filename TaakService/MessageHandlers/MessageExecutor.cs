using System;
using System.Threading.Tasks;
using TaakService.MessageHandlers.CommandHandlers;
using TaakService.MessageHandlers.QueryHandlers;
using TaakService.Messages.Commands;
using TaakService.Messages.Queries;

namespace TaakService.MessageHandlers
{
    public interface IMessageExecutor
    {
        Task ExecuteAsync(ICommand command);

        Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query);
    }

    public class MessageExecutor : IMessageExecutor
    {
        private IServiceProvider serviceProvider;

        public MessageExecutor(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task ExecuteAsync(ICommand command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = serviceProvider.GetService(handlerType);
            await handler.HandleAsync((dynamic)command);
        }

        public async Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = serviceProvider.GetService(handlerType);
            TResult result = await handler.HandleAsync((dynamic)query);

            return result;
        }
    }
}
