using DependencyInjection.Dependencies.Dependency2.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace DependencyInjection.Dependencies
{
    public class Dependency_2 : IDependency2
    {
        private readonly Dependency2Options _options;
        private readonly ILogger<Dependency_2> _logger;

        public Dependency_2(IOptions<Dependency2Options> options, ILogger<Dependency_2> logger)
        {
            _options = options.Value;
            _logger = logger;
        }

        public string GetPrettyJsonOfOptions()
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(_options, jsonSerializerOptions);
            _logger.LogDebug("Dependency_2::GetPrettyJsonOfOptions() returns {json}", json);

            return json;
        }
    }
}