using Microsoft.Extensions.DependencyInjection;
using Modular.Abstractions.Kernel;
using System.Collections.Generic;
using System.Reflection;

namespace Modular.Infrastructure.Kernel;

public static class Extensions
{
    public static IServiceCollection AddDomainEvents(this IServiceCollection services,
        IEnumerable<Assembly> assemblies)
    {
        services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();
        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IDomainEventHandler<>))
                .WithoutAttribute<DecoratorAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}