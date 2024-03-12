using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modular.Infrastructure;
using Modular.Infrastructure.Messaging.Outbox;
using Modular.Infrastructure.Postgres;
using Modular.Modules.Users.Core;
using Modular.Modules.Users.Core.DAL;
using Modular.Modules.Users.Core.DAL.Repositories;
using Modular.Modules.Users.Core.Entities;
using Modular.Modules.Users.Core.Repositories;
using Modular.Modules.Users.Core.Services;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DeepFocus.Modules.Users.Api")]
namespace DeepFocus.Modules.Users.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            var registrationOptions = configuration.GetOptions<RegistrationOptions>("users:registration");
            services.AddSingleton(registrationOptions);

            return services
                .AddSingleton<IUserRequestStorage, UserRequestStorage>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
                .AddPostgres<UsersDbContext>(configuration)
                .AddOutbox<UsersDbContext>(configuration)
                .AddUnitOfWork<UsersUnitOfWork>()
                .AddInitializer<UsersInitializer>();
        }
    }
}
