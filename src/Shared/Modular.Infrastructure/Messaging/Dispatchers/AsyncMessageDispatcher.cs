using Modular.Abstractions.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace Modular.Infrastructure.Messaging.Dispatchers;

public sealed class AsyncMessageDispatcher : IAsyncMessageDispatcher
{
    private readonly IMessageChannel _channel;
    private readonly IMessageContextProvider _messageContextProvider;

    public AsyncMessageDispatcher(IMessageChannel channel, IMessageContextProvider messageContextProvider)
    {
        _channel = channel;
        _messageContextProvider = messageContextProvider;
    }

    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken = default)
        where T : class, IMessage
    {
        var messageContext = _messageContextProvider.Get(message);
        await _channel.Writer.WriteAsync(new MessageEnvelope(message, messageContext), cancellationToken);
    }
}