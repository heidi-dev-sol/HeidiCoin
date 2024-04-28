namespace HeidiCoin.Core.Services.Hashing.Sha3.Implementations.Tests;

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
    public void CalculateHashAsync_ValidBlock_Test()
    {
        //ARRANGE
        var instance = base.ServiceProvider.GetRequiredService<IBlockHashService>();

        //ACT
        //ASSERT
        Assert.Pass();
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