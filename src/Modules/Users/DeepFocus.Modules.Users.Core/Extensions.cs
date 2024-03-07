using DeepFocus.Modules.Users.Core.DAL;
using DeepFocus.Modules.Users.Core.DAL.Repositories;
using DeepFocus.Modules.Users.Core.Entities;
using DeepFocus.Modules.Users.Core.Repositories;
using DeepFocus.Modules.Users.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modular.Infrastructure.Postgres;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DeepFocus.Modules.Users.Api")]
namespace DeepFocus.Modules.Users.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddScoped<IUserRepository, UserRepository>()
                .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddPostgres<UsersDbContext>(configuration);
    }
}
