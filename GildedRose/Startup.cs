using GildedRoseKata.Services;
using GildedRoseKata.Settings;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace GildedRoseKata;

internal static class Startup
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        services
            .AddScoped<IConsoleService, ConsoleService>()
            .AddScoped<IAgingService, AgingService>();

        return services;
    }

    public static IServiceCollection AddLogging(
        this IServiceCollection services,
        HostBuilderContext hostContext)
    {
        var loggingSettings = hostContext.Configuration
            .GetSection(nameof(LoggingSettings))
            .Get<LoggingSettings>();

        if (loggingSettings == null)
        {
            var loggerConfiguration = new LoggerConfiguration();

            loggerConfiguration
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    LogEventLevel.Information,
                    theme: SystemConsoleTheme.Literate)
                .WriteTo.File(
                    rollOnFileSizeLimit: true,
                    path: loggingSettings.LogFilePath,
                    fileSizeLimitBytes: loggingSettings.FileSizeLimitBytes);

            Log.Logger = loggerConfiguration.CreateLogger();
        }

        return services;
    }
}
