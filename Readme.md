## Client Credentials Usage



## Client Credentials using Client Secrets

1. Add the following configuration section to your appsettings.json files, and populate it appropriately.


```json
 "ClientCredentialsConfiguration" : {
    "Authority":"",
    "ClientId":"",
    "ClientSecret":"",
    "Scopes":"",
    "Apis":[
     {"Name":"",
      "Url":"",
      "Scope":""
      }
    ]
    }

```

If you want to disable the authorization for some reason, you can add another property named `Enable` to the ClientCredentialsConfiguration, it is default true.

2. Add package `Fhi.ClientCredentialsUsingSecrets` to your project
3. In your `Program.cs` file, create an instance of the `ClientCredentialsSetup` class using an `IConfiguration` parameter.
4. Using the created instance call the method `ConfigureServices`.

## Client Credentials using Keypairs

1.Add the following configuration section to your appsettings.json files, and populate it appropriately.

2. In your `Program.cs` file, or if older `Startup.cs`, add the following section:

```cs
 services.AddHttpClient(nameof(YourService), c =>
         {
             c.Timeout = new TimeSpan(0, 0, 0, 10);
             c.BaseAddress = new Uri(clientCredentialsConfiguration.Url);
         })
         .AddHttpMessageHandler<HttpAuthHandler>()
         .AddTypedClient(c => RestService.For<IExternalApi>(c, new RefitSettings
         {
             ContentSerializer = new SystemTextJsonContentSerializer(options)
         }));
```
replacing `YourService` with the service you have done for accessing the external api, and replace `IExternalApi` with the Refit interface for whatever external api you want to access.

If you don't use Refit, you can just skip the last part, and get the named client from the injected HttpFactory in your service. It will still have the authenticatiohandler, so you don't need to do anything more there.

