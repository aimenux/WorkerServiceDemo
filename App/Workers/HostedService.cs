using App.Helpers;
using App.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.Workers
{
    public class HostedService : BackgroundService
    {
        private readonly ICustomLogger _logger;
        private readonly IConsoleRender _render;
        private readonly IEnumerable<IConfigurationService> _services;
        private static readonly TimeSpan Delay = TimeSpan.FromSeconds(5);

        public HostedService(IEnumerable<IConfigurationService> services, IConsoleRender render, ICustomLogger logger)
        {
            _services = services;
            _render = render;
            _logger = logger;
        }

        public override async Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogToAllLevels("Starting worker");

            await base.StartAsync(stoppingToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogToAllLevels("Running worker");

            while (!stoppingToken.IsCancellationRequested)
            {
                _render.RenderMessage($"{DateTime.Now:F}");

                foreach (var configurationService in _services)
                {
                    var title = configurationService.GetType().Name;
                    var features = configurationService.GetFeatures();
                    _render.RenderFeatures(title, features);
                }

                await Task.Delay(Delay, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogToAllLevels("Stopping worker");

            await base.StopAsync(stoppingToken);
        }
    }
}
