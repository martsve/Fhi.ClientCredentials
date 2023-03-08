using Fhi.ClientCredentialsKeypairs;
using NUnit.Framework;

namespace Fhi.ClientCredentials.TestSupport;

public abstract class ClientCredentialKeyPairsConfigConsistencyTests
{
    private List<ClientCredentialsConfiguration> ClientCredentialsConfigurationForTests { get; } = new();

    private readonly SetupBaseConfigTests.AppSettingsUsage useOfAppsettings;

    private readonly ClientCredentialsConfiguration clientCredentialsConfigurationForProduction = null!;

    /// <summary>
    /// Add the different types of appsettings you have for tests,  e.g. appsettings.test.json => test
    /// </summary>
    protected ClientCredentialKeyPairsConfigConsistencyTests(IEnumerable<string> types, SetupBaseConfigTests.AppSettingsUsage useOfAppsettings, string prod = "")
    {
        this.useOfAppsettings = useOfAppsettings;
        var fileNamesForTests = types.Select(o => $"appsettings.{o}.json");

        foreach (var fileName in fileNamesForTests)
        {
            var workerConfig = new ClientCredentialsClientIds(fileName, useOfAppsettings).ClientCredentialsConfigurationUnderTest;
            ClientCredentialsConfigurationForTests.Add(workerConfig);
        }
            
        switch (useOfAppsettings)
        {
            case SetupBaseConfigTests.AppSettingsUsage.AppSettingsIsProd:
                clientCredentialsConfigurationForProduction = new ClientCredentialsClientIds("appsettings.json", useOfAppsettings).ClientCredentialsConfigurationUnderTest;
                break;
            case SetupBaseConfigTests.AppSettingsUsage.AppSettingsIsExplicit:
            case SetupBaseConfigTests.AppSettingsUsage.AppSettingsIsTestWhenDev:
                break;
            case SetupBaseConfigTests.AppSettingsUsage.AppSettingsIsBaseOnly:
                clientCredentialsConfigurationForProduction = new ClientCredentialsClientIds($"appsettings.{prod}.json", useOfAppsettings).ClientCredentialsConfigurationUnderTest;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(useOfAppsettings), useOfAppsettings, null);
        }
    }

    [Test]
    public void ThatClientIdsAreConsistent()
    {
        var clientIds = ClientCredentialsConfigurationForTests.DistinctBy(o => o.ClientId);
        var count = clientIds.Count();
        Assert.That(count, Is.EqualTo(1),
            $"The appsettings for test are using {count} different clientIds, instead of one");

    }

    [Test]
    public void ThatPrivateJwkKeysAreConsistent()
    {
        var privateJwks = ClientCredentialsConfigurationForTests.DistinctBy(o => o.privateJwk);
        var count = privateJwks.Count();
        Assert.That(count, Is.EqualTo(1),
            $"The appsettings for test are using {count} different private Jwk Keys, instead of one");

    }

    [Test]
    public void ThatClientIdForProductionIsDifferentThanTest()
    {
        if (useOfAppsettings == SetupBaseConfigTests.AppSettingsUsage.AppSettingsIsTestWhenDev ||
            useOfAppsettings == SetupBaseConfigTests.AppSettingsUsage.AppSettingsIsExplicit)
        {
            Assert.Inconclusive("No way to tell");
            return;
        }
        var clientIds = ClientCredentialsConfigurationForTests.DistinctBy(o => o.ClientId);
        Assert.That(clientCredentialsConfigurationForProduction.ClientId, Is.Not.EqualTo(clientIds.First()), "ClientId for production is equal to clientId used for tests");
    }

    [Test]
    public void ThatPrivateJwkKeyForProductionIsDifferentThanTest()
    {
        if (useOfAppsettings == SetupBaseConfigTests.AppSettingsUsage.AppSettingsIsTestWhenDev ||
            useOfAppsettings == SetupBaseConfigTests.AppSettingsUsage.AppSettingsIsExplicit)
        {
            Assert.Inconclusive("No way to tell");
            return;
        }
        var keyPairs = ClientCredentialsConfigurationForTests.DistinctBy(o => o.privateJwk);
        Assert.That(clientCredentialsConfigurationForProduction.privateJwk, Is.Not.EqualTo(keyPairs.First()), "Private Jwk Key for production is equal to what is used for tests");
    }
}