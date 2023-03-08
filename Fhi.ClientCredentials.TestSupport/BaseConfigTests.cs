using Fhi.ClientCredentialsKeypairs;
using NUnit.Framework;

namespace Fhi.ClientCredentials.TestSupport;

public abstract class BaseConfigTests : SetupBaseConfigTests
{
    protected bool IsTest { get; }

    protected BaseConfigTests(string configFile, bool test, AppSettingsUsage useOfAppsettings) : base(configFile, useOfAppsettings)
    {
        IsTest = test;
    }

    protected abstract ClientCredentialsConfiguration ClientCredentialsConfigurationUnderTest { get; }

    [Test]
    public void AuthorityConfigurationTest()
    {
        const string testAuthorityUrl = "https://helseid-sts.test.nhn.no/";
        const string authorityUrl = "https://helseid-sts.nhn.no/";
        Guard();
        var authority = IsTest ? testAuthorityUrl : authorityUrl;
        Assert.That(ClientCredentialsConfigurationUnderTest.Authority, Does.StartWith(authority), $"Wrong authority found: {ClientCredentialsConfigurationUnderTest.Authority} in {ConfigFile}. Only possible with {testAuthorityUrl} for test, and {authorityUrl} for production");
    }
}