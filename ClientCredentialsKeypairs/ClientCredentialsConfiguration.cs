namespace Fhi.ClientCredentialsKeypairs;

public partial class ClientCredentialsConfiguration
{
    public string Authority => authority;
    public string ClientId => clientId;
    public string Scopes => scopes == null ? "" : string.Join(" ", scopes);

    public string PrivateKey => privateJwk;

    /// <summary>
    /// Set this lower than the lifetime of the access token
    /// </summary>
    public int RefreshTokenAfterMinutes { get; set; } = 8;
    public List<Api> Apis { get; set; } = new();
}

public class Api
{
    /// <summary>
    /// User friendly name of the Api, prefer using nameof(WhateverApiService)
    /// </summary>
    public string Name { get; set; } = "";
    
    /// <summary>
    /// Actual Url to Api
    /// </summary>
    public string Url { get; set; } = "";
}