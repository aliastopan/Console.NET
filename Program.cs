using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

using Hosted.Console.Interfaces;
using Hosted.Console.Services;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) => {
        services.AddTransient<IStartupService, StartupService>();
    })
    .ConfigureLogging((context, logging) => {

    })
    .UseSerilog()
    .Build();

var app = ActivatorUtilities.CreateInstance<StartupService>(host.Services);

app.Run();
app.Flush();
