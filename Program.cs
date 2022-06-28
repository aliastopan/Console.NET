using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Hosted.Console.Interfaces;
using Hosted.Console.Services;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) => {
        services.AddTransient<IStartupService, StartupService>();
    })
    .ConfigureLogging((context, logging) => {
        logging.ClearProviders();
        logging.AddConfiguration(context.Configuration.GetSection("Logging"));
        logging.AddConsole();
    })
    .Build();

var startup = ActivatorUtilities.CreateInstance<StartupService>(host.Services);

startup.Run();
startup.Flush();
