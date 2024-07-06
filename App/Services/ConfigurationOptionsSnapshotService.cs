using App.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace App.Services;

public class ConfigurationOptionsSnapshotService : IConfigurationService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ConfigurationOptionsSnapshotService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public Features GetFeatures()
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<Features>>();
        var features = options.Value;
        return features;
    }
}