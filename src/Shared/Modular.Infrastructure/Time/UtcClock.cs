using Modular.Abstractions.Time;
using System;

namespace Modular.Infrastructure.Time;

public class UtcClock : IClock
{
    public DateTime CurrentDate() => DateTime.UtcNow;
}