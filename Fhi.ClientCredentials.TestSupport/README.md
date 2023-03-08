# Fhi.ClientCredentials.TestSupport

This package contains tests that checks your appsettings.*.json files for correct configuration of the ClientCredentials package.
It checks that your settings for test and production are different, and that all your different test and dev projects uses the same settings.

The assumption here is that your production use a production based STS (Secure Token Service), wheres the other enviornments all use the same Test STS.

The package has a default STS of the NHN HelseId STS.  This can be changed by overriden the STS properties in the main class, see below for details.

## Usage

Include the package in your test project.

Add the following test class to your project.  In the base part of the constructor, list the differerent environments you have appsettings for, and for which there exists an `appsettings.XXX.json` file.

```csharp
public class ClientConsistencyTests : Fhi.ClientCredentials.TestSupport.ClientCredentialKeyPairsConfigConsistencyTests
{
    public ClientConsistencyTests() : base(new List<string> { "QA", "AzureDev", "Test", "Development" },SetupBaseConfigTests.AppSettingsUsage.AppSettingsIsBaseOnly)
    {
    }
}
```
The different alternatives for the second base parameter, AppSettingsUsage is as follows:
```csharp
 public enum AppSettingsUsage
    {
        AppSettingsIsProd,  // appsettings.prod exist and is merged with appsettings.json
        AppSettingsIsBaseOnly, // No seperate prod exist, appsettings.json is production, but when anything else is specified, merge is to happen
        AppSettingsIsTestWhenDev, // When developing, appsettings is development,  require seperate prod
        AppSettingsIsExplicit // Use only the specified appsettings.
    }
```

