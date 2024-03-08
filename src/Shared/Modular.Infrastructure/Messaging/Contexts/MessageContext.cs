using Modular.Abstractions.Contexts;
using Modular.Abstractions.Messaging;
using System;

namespace Modular.Infrastructure.Messaging.Contexts;

public class MessageContext : IMessageContext
{
    public Guid MessageId { get; }
    public IContext Context { get; }

    public MessageContext(Guid messageId, IContext context)
    {
        MessageId = messageId;
        Context = context;
    }
}