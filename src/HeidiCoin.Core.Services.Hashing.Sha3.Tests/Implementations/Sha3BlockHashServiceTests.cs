namespace HeidiCoin.Core.Services.Hashing.Sha3.Implementations.Tests;

using HeidiCoin.Core.Models.Sources;
using HeidiCoin.Core.Services.Hashing.Contracts;
using HeidiCoin.Tests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class Sha3BlockHashServiceTests : BaseTestHarness
{
    //TODO: Look to bring in base harness
    [Test]
    public async Task CalculateHashAsync_ValidBlock_NotNull_Test()
    {
        //ARRANGE
        var instance = base.ServiceProvider.GetRequiredService<IBlockHashService>();

        var block = BlocksSource.CreateBlock(123456789, "0x00");

        //ACT
        block = await instance.CalculateHashAsync(block);

        //ASSERT
        Assert.That(block, Is.Not.Null);
    }    
    
    [Test]
    public async Task CalculateHashAsync_ValidBlock_HashIsNotNull_Test()
    {
        //ARRANGE
        var instance = base.ServiceProvider.GetRequiredService<IBlockHashService>();

        var block = BlocksSource.CreateBlock(123456789, "0x00");

        //ACT
        block = await instance.CalculateHashAsync(block);

        //ASSERT
        Assert.That(block.Hash, Is.Not.Null);
    }    
    
    [Test]
    public async Task CalculateHashAsync_ValidBlock_HashIsNotEmpty_Test()
    {
        //ARRANGE
        var instance = base.ServiceProvider.GetRequiredService<IBlockHashService>();

        var block = BlocksSource.CreateBlock(123456789, "0x00");

        //ACT
        block = await instance.CalculateHashAsync(block);

        //ASSERT
        Assert.That(block.Hash, Is.Not.Empty);
    }

    [Test]
    public void IsBlockHashValidAsyncTest()
    {
        Assert.Fail();
    }

    [Test]
    public void IsPreviousBlockAsyncTest()
    {
        Assert.Fail();
    }
}