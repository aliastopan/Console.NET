using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Hosted.Console.Interfaces;

namespace Hosted.Console.Services;

internal sealed class StartupService : IStartupService
{
    private readonly ILogger<StartupService> _log;
    private readonly IConfiguration _config;

    public StartupService(ILogger<StartupService> log, IConfiguration config)
    {
        _log = log;
        _config = config;
    }

    public void Run()
    {
        _log.LogInformation($"{_config.GetValue<string>("Startup")}");
    }

    public void Flush()
    {
        System.Console.ReadLine();
    }
}