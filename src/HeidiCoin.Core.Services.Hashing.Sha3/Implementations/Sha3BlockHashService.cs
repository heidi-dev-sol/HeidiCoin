using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeidiCoin.Core.Services.Hashing.Sha3.Implementations
{
    using System.Security.Cryptography;
    using HeidiCoin.Core.Models.Contracts;
    using HeidiCoin.Core.Services.Hashing.Contracts;using HeidiCoin.Core.Services.Implementations;
    using Microsoft.Extensions.Logging;

    public class Sha3BlockHashService(ILogger logger) : BaseService(logger), IBlockHashService
    {
        public async ValueTask<IBlock> CalculateHashAsync(IBlock block)
        {
            try
            {
                var blockComputableSignature = block.GetComputableSignature();

                var hash = SHA3_512.HashData(blockComputableSignature);

                block.Hash = Convert.ToHexString(hash);

                return block;
            }
            catch (Exception exception)
            {
                //TODO: Create an exception policy manager
                this.Logger.LogError(exception, exception.Message);

                return block;
            }
        }

        public async ValueTask<bool> IsBlockHashValidAsync(IBlock block)
        {
            try
            {
                var hashToCompare = await this.CalculateHashAsync(block);

                return string.Equals(hashToCompare.Hash, block.Hash, StringComparison.CurrentCultureIgnoreCase);
            }
            catch (Exception exception)
            {
                //TODO: Create an exception policy manager
                this.Logger.LogError(exception, exception.Message);

                return false;
            }
        }

        public async ValueTask<bool> IsPreviousBlockAsync(IBlock currentBlock, IBlock blockToCompare)
        {
            try
            {
                return string.Equals(currentBlock.PreviousHash, blockToCompare.Hash, StringComparison.CurrentCultureIgnoreCase);
            }
            catch (Exception exception)
            {
                //TODO: Create an exception policy manager
                this.Logger.LogError(exception, exception.Message);

                return false;
            }
        }
    }
}
