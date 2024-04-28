using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeidiCoin.Core.Services.Hashing.Contracts
{
    using HeidiCoin.Core.Models.Contracts;
    using HeidiCoin.Core.Services.Contracts;

    public interface IBlockHashService : IService
    {
        ValueTask<IBlock> CalculateHashAsync(IBlock block);
        ValueTask<bool> IsBlockHashValidAsync(IBlock block);
        ValueTask<bool> IsPreviousBlockAsync(IBlock currentBlock, IBlock blockToCompare);
    }
}
