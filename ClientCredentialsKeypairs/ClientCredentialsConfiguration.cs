namespace Fhi.ClientCredentialsKeypairs;

public partial class ClientCredentialsConfiguration
{
    public string Authority => authority;
    public string ClientId => clientId;
    public string Scopes => scopes == null ? "" : string.Join(" ", scopes);

    public string PrivateKey => privateJwk;

    public string Url => url;

    public int RefreshTokenAfterMinutes { get; set; }
    public string url { get; set; } = "";
}