using DeepFocus.Modules.Users.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modular.Abstractions.Modules;


namespace DeepFocus.Modules.Users.Api
{
    internal class UsersModule : IModule
    {
        public const string BasePath = "users-module";
        public string Name { get; } = "Users";
        public string Path => BasePath;

        public IEnumerable<string> Policies { get; } = new[]
        {
         "users"
        };

        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCore(configuration);
        }

        public void Use(IApplicationBuilder app)
        {
        }
    }
}
