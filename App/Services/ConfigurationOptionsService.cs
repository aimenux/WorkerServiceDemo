using App.Models;
using Microsoft.Extensions.Options;

namespace App.Services;

public class ConfigurationOptionsService : IConfigurationService
{
    private readonly IOptions<Features> _options;

    public ConfigurationOptionsService(IOptions<Features> options)
    {
        _options = options;
    }

    public Features GetFeatures() => _options.Value;
}