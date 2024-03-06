using Modular.Abstractions.Modules;
using Modular.Infrastructure;
using Modular.Infrastructure.Modules;
using System.Reflection;

namespace DeepFocus.Bootstrapper
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IList<Assembly> _assemblies;
        private readonly IList<IModule> _modules;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _assemblies = ModuleLoader.LoadAssemblies(configuration, "DeepFocus.Modules.");
            _modules = ModuleLoader.LoadModules(_assemblies);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddModularInfrastructure(_configuration, _assemblies, _modules);
            foreach (var module in _modules)
            {
                module.Register(services, _configuration);
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation($"Modules: {string.Join(", ", _modules.Select(x => x.Name))}");
            app.UseModularInfrastructure();
            foreach (var module in _modules)
            {
                module.Use(app);
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", context => context.Response.WriteAsync("DeepFocus API!"));
                endpoints.MapModuleInfo();
            });

            //app.UseConvey();
            //app.UseRabbitMq();

            _assemblies.Clear();
            _modules.Clear();
        }
    }
}
