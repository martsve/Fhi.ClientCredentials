using Fhi.ClientCredentialsKeypairs;
using Microsoft.Extensions.Configuration;

namespace Fhi.ClientCredentials.TestSupport;

public class ClientCredentialsClientIds : SetupBaseConfigTests
{
    public ClientCredentialsConfiguration ClientCredentialsConfigurationUnderTest { get; set; }
    public ClientCredentialsClientIds(string configFile, AppSettingsUsage useOfAppsettings) : base(configFile, useOfAppsettings)
    {
        ClientCredentialsConfigurationUnderTest = Config.GetSection(nameof(ClientCredentialsConfiguration))
            .Get<ClientCredentialsConfiguration>();
    }

    protected override void Guard()
    {
        // Does nothing here
    }
}