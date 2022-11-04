namespace Fhi.ClientCredentialsUsingSecrets;

public class ClientCredentialsConfiguration
{
    public bool Enable { get; set; } = true;
    public string Authority { get; set; } = "";
    public string ClientId { get; set; } = "";
    public string ClientSecret { get; set; } = "";

    public string Scopes { get; set; } = "";

    public ApiKonfigurasjon[] Apis { get; set; } = Array.Empty<ApiKonfigurasjon>();
}