namespace HeidiCoin.Core.Dependencies.Registrations;

using HeidiCoin.Core.Services.Hashing.Contracts;
using HeidiCoin.Core.Services.Hashing.Sha3.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

public static class DependencyRegistration
{
    public static IServiceCollection AddSerilogFileLogging(this IServiceCollection serviceCollection)
    {
        var log = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("HeidiCoin.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        serviceCollection.AddLogging(logger => logger.AddSerilog(log));

        var logger = LoggerFactory.Create(logger => logger.AddSerilog(log)).CreateLogger("HeidiCoin.Logger");

        return serviceCollection.AddSingleton<ILogger>(logger);
    }

    public static IServiceCollection AddBlockchainHashingServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IBlockHashService, Sha3BlockHashService>();
    }
}