using DependencyInjection.Dependencies.Dependency1.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace DependencyInjection.Dependencies
{
    public class Dependency_1 : IDependency1
    {
        private readonly Dependency1Options _options;
        private readonly ILogger<Dependency_1> _logger;

        public Dependency_1(IOptions<Dependency1Options> options, ILogger<Dependency_1> logger)
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
            _logger.LogDebug("Dependency_1::GetPrettyJsonOfOptions() returns {json}", json);

            return json;
        }
    }
}
