namespace HeidiCoin.Core.Models.Sources;

using HeidiCoin.Core.Models.Contracts;
using HeidiCoin.Core.Models.Implementations;

public static class BlocksSource
{
    public static IBlock CreateBlock(long index, string previousHash) => new Block(index, previousHash);

    public static IBlock CreateGenisisBlock => BlocksSource.CreateBlock(0, string.Empty);
}