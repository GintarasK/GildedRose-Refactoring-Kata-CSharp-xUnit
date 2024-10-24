using System;
using System.IO;
using System.Reflection;

using GildedRoseKata.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;

namespace GildedRoseKata;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var serviceProvider = scope.ServiceProvider;

            serviceProvider.GetRequiredService<Application>().Process();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureAppConfiguration((hostContext, builder) =>
            {
                builder
                    .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                    .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<Application>()
                .AddSingleton<IItemObserver>(new ItemObserver(DataProvider.Items))
                .AddServices()
                .AddLogging(hostContext);
            });
}