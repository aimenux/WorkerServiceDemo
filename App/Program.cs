using App.Helpers;
using App.Models;
using App.Services;
using App.Workers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.IO;
using System.Threading.Tasks;

namespace App;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await CreateHostBuilder(args).Build().RunAsync();
        Console.WriteLine("Press any key to exit !");
        Console.ReadKey();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, config) =>
            {
                config.AddCommandLine(args);
                config.AddEnvironmentVariables();
                config.SetBasePath(Directory.GetCurrentDirectory());
                var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);
            })
            .ConfigureLogging((hostingContext, loggingBuilder) =>
            {
                loggingBuilder.AddDebug();
                loggingBuilder.AddEventLogger();
                loggingBuilder.AddEventSourceLogger();
                loggingBuilder.AddConsoleLogger();
                loggingBuilder.AddNonGenericLogger();
                loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection(@"Logging"));
            })
            .ConfigureServices((hostingContext, services) =>
            {
                services.AddOptions();
                services.AddHostedService<HostedService>();
                services.AddTransient<ICustomLogger, CustomLogger>();
                services.AddTransient<IConsoleRender, ConsoleRender>();
                services.AddTransient<IConfigurationService, ConfigurationOptionsService>();
                services.AddTransient<IConfigurationService, ConfigurationOptionsMonitorService>();
                services.AddTransient<IConfigurationService, ConfigurationOptionsSnapshotService>();
                services.Configure<Features>(hostingContext.Configuration.GetSection(nameof(Features)));
            })
            .UseConsoleLifetime()
            .UseWindowsService()
            .UseSystemd();

    private static void AddConsoleLogger(this ILoggingBuilder loggingBuilder)
    {
        loggingBuilder.AddSimpleConsole(options =>
        {
            options.SingleLine = true;
            options.IncludeScopes = true;
            options.TimestampFormat = "[HH:mm:ss:fff] ";
            options.ColorBehavior = LoggerColorBehavior.Enabled;
        });
    }

    private static void AddNonGenericLogger(this ILoggingBuilder loggingBuilder)
    {
        var services = loggingBuilder.Services;
        services.AddSingleton(serviceProvider =>
        {
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            return loggerFactory.CreateLogger(@"WorkerServiceDemo");
        });
    }
}