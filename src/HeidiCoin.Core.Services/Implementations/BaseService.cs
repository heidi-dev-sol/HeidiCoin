using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeidiCoin.Core.Services.Implementations
{
    using HeidiCoin.Core.Services.Contracts;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public abstract class BaseService(ILogger logger) : IService
    {
        protected readonly ILogger Logger = logger;
    }
    public abstract class BaseService<TOptions>(ILogger logger, IOptions<TOptions> options) : IService where TOptions : class
    {
        protected readonly IOptions<TOptions> Options = options;
        protected readonly ILogger Logger = logger;
    }
}
