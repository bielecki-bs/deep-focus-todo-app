using Modular.Abstractions.Commands;
using Modular.Abstractions.Events;
using Modular.Abstractions.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Modular.Abstractions.Dispatchers;

public interface IDispatcher
{
    Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;
    Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class, IEvent;
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}