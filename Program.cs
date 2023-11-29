using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {

    })
    .UseSerilog()
    .Build();

Log.Information("Starting...");