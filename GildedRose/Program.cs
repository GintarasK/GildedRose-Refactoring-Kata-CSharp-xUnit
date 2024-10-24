using System;

using GildedRoseKata.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GildedRoseKata;

public static class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using var scope = host.Services.CreateScope();

        var serviceProvider = scope.ServiceProvider;

        try
        {
            serviceProvider.GetRequiredService<Application>().Process();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<Application>()
                .AddSingleton<IItemObserver>(new ItemObserver(DataProvider.Items))
                .AddServices();
            });
}