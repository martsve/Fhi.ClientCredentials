using Microsoft.Extensions.Options;

namespace Fhi.ClientCredentialsKeypairs
{
    public class AuthenticationStore : IAuthTokenStore
    {
        private readonly IAuthenticationService authenticationService;
        private DateTime tokenDateTime;
        private readonly int refreshTokenAfterMinutes;

        public AuthenticationStore(IAuthenticationService authenticationService, IOptions<ClientCredentialsConfiguration> configuration)
        {
            refreshTokenAfterMinutes = configuration.Value.RefreshTokenAfterMinutes;
            this.authenticationService = authenticationService;
            Refresh();
        }
        public string GetToken()
        {
            if((DateTime.Now - tokenDateTime).TotalMinutes > refreshTokenAfterMinutes)
            {
                Refresh();
            }
            return authenticationService.AccessToken;
        }

        private void Refresh()
        {
            var x = authenticationService.SetupToken();
            x.Wait();
            tokenDateTime = DateTime.Now;
        }
    }
}
