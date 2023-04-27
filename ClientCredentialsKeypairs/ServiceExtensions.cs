using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Fhi.ClientCredentialsKeypairs
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Setup the client credentials keypairs authentication
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns>The loaded ClientCredentialsConfiguration</returns>
        /// <exception cref="ConfigurationException"></exception>
        public static ClientCredentialsConfiguration AddClientCredentialsKeypairs(this IServiceCollection services, IConfiguration configuration)
        {
            var configClientCredentialsSection = configuration.GetSection(nameof(ClientCredentialsConfiguration));
            var clientCredentialsConfiguration = configClientCredentialsSection.Get<ClientCredentialsConfiguration>();
            if (clientCredentialsConfiguration == null)
                throw new ConfigurationException("Missing configuration: ClientCredentialsConfiguration");
            services.Configure<ClientCredentialsConfiguration>(configuration.GetSection(nameof(ClientCredentialsConfiguration)));
            services.AddTransient<IAuthenticationService>(_ => new AuthenticationService(clientCredentialsConfiguration));
            services.AddSingleton<IAuthTokenStore, AuthenticationStore>();
            services.AddTransient<HttpAuthHandler>();
            return clientCredentialsConfiguration;
        }

        public static JsonSerializerOptions DefaultJsonSerializationOptions(this IServiceCollection services)
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IgnoreReadOnlyProperties = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
            return jsonSerializerOptions;
        }
    }
}
