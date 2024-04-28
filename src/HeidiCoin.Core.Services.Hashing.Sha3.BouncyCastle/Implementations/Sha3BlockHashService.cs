namespace HeidiCoin.Core.Services.Hashing.Sha3.Implementations;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using HeidiCoin.Core.Models.Contracts;
using HeidiCoin.Core.Services.Hashing.Contracts;
using HeidiCoin.Core.Services.Implementations;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto.Digests;

public class Sha3BlockHashService(ILogger logger) : BaseService(logger), IBlockHashService
{
    public async ValueTask<IBlock> CalculateHashAsync(IBlock block)
    {
        try
        {
            var blockComputableSignature = block.GetComputableSignature();
            
            var hashingProvider = new Sha3Digest();

            hashingProvider.BlockUpdate(blockComputableSignature, 0, blockComputableSignature.Length);

            var hashedSignature = new byte[32];

            hashingProvider.DoFinal(hashedSignature);

            block.Hash = Convert.ToHexString(hashedSignature);

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
            return string.Equals(currentBlock.PreviousHash, blockToCompare.Hash,
                StringComparison.CurrentCultureIgnoreCase);
        }
        catch (Exception exception)
        {
            //TODO: Create an exception policy manager
            this.Logger.LogError(exception, exception.Message);

            return false;
        }
    }
}