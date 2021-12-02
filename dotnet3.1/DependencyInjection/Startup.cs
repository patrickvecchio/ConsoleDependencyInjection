using DependencyInjection.Dependencies;
using DependencyInjection.Dependencies.Dependency1.Options;
using DependencyInjection.Dependencies.Dependency2.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace DependencyInjection
{
    internal class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IServiceProvider provider;

        public IServiceProvider Provider => provider;
        public IConfiguration Configuration => configuration;

        public Startup()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{environment}.json", optional: true)
                            .AddEnvironmentVariables()
                            .Build();

            // instantiate
            var services = new ServiceCollection();

            // add necessary services
            services.AddSingleton<IConfiguration>(configuration);

            services.AddLogging(logging =>
            {
                logging.AddConsole();
            });

            services.AddOptions<Dependency1Options>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("dependency1").Bind(settings);
                });

            services.AddScoped<IDependency1, Dependency_1>();

            services.AddOptions<Dependency2Options>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("dependency2").Bind(settings);
                });

            services.AddScoped<IDependency2, Dependency_2>();

            // build the pipeline
            provider = services.BuildServiceProvider();
        }
    }
}
