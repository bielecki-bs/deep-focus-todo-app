using Modular.Abstractions.Messaging;
using System.Threading.Tasks;

namespace Modular.Infrastructure.Messaging.Outbox;

public interface IOutboxBroker
{
    bool Enabled { get; }
    Task SendAsync(params IMessage[] messages);
}