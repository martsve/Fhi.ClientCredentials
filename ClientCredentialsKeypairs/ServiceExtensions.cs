using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fhi.ClientCredentialsKeypairs
{
    public static class ServiceExtensions
    {
        public static ClientCredentialsConfiguration RegisterForClientCredentialsKeypairs(this IServiceCollection services, IConfiguration configuration)
        {
            var configClientCredentialsSection = configuration.GetSection(nameof(ClientCredentialsConfiguration));
            var clientCredentialsConfiguration = configClientCredentialsSection.Get<ClientCredentialsConfiguration>();
            services.Configure<ClientCredentialsConfiguration>(configuration.GetSection(nameof(ClientCredentialsConfiguration)));
            services.AddTransient<IAuthenticationService>(_ => new AuthenticationService(clientCredentialsConfiguration));
            services.AddSingleton<IAuthTokenStore, AuthenticationStore>();
            services.AddTransient<HttpAuthHandler>();
            return clientCredentialsConfiguration;
        }
    }
}
