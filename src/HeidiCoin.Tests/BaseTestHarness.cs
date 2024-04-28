namespace HeidiCoin.Tests;

using System;
using HeidiCoin.Core.Dependencies.Configuration;
using HeidiCoin.Core.Dependencies.Registrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

[SetUpFixture]
public abstract class BaseTestHarness
{
    private IServiceCollection ServiceCollection { get; set; }
    public IServiceProvider ServiceProvider { get; set; }
    protected IConfiguration Configuration { get; private set; }

    [SetUp]
    public void OnTestInitialise()
    {
        this.ServiceCollection = new ServiceCollection();

        var globalConfiguration = ApplicationConfigurationProvider.GetGlobalConfiguration();

        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddConfiguration(globalConfiguration);

        this.ServiceCollection.AddSerilogFileLogging();
        this.ServiceCollection.AddBlockchainHashingServices();

        this.Configuration = configurationBuilder.Build();

        this.ServiceProvider = this.ServiceCollection.BuildServiceProvider();
    }
}