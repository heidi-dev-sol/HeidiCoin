namespace HeidiCoin.Core.Services.Implementations;

using HeidiCoin.Core.Services.Contracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public abstract class BaseService(ILogger logger) : IService
{
    protected readonly ILogger Logger = logger;
}

public abstract class BaseService<TOptions>(ILogger logger, IOptions<TOptions> options)
    : IService where TOptions : class
{
    protected readonly ILogger Logger = logger;
    protected readonly IOptions<TOptions> Options = options;
}