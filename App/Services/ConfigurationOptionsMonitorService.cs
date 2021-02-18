using App.Models;
using Microsoft.Extensions.Options;

namespace App.Services
{
    public class ConfigurationOptionsMonitorService : IConfigurationService
    {
        private readonly IOptionsMonitor<Features> _options;

        public ConfigurationOptionsMonitorService(IOptionsMonitor<Features> options)
        {
            _options = options;
        }

        public Features GetFeatures() => _options.CurrentValue;
    }
}
