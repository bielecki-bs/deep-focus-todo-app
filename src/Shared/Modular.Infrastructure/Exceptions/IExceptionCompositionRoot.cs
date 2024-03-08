using Modular.Abstractions.Exceptions;
using System;

namespace Modular.Infrastructure.Exceptions;

public interface IExceptionCompositionRoot
{
    ExceptionResponse Map(Exception exception);
}