using Modular.Abstractions.Contexts;
using System;

namespace Modular.Abstractions.Messaging;

public interface IMessageContext
{
    public Guid MessageId { get; }
    public IContext Context { get; }
}