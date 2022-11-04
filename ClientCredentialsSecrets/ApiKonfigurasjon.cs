using System.Text.Json.Serialization;

namespace Fhi.ClientCredentials;

public class ApiKonfigurasjon
{
    public string Name { get; set; } = "";
    public string Url { get; set; } = "";
    public string Scope { get; set; } = "";

    [JsonIgnore]
    public Uri? Uri => string.IsNullOrEmpty(Url) ? null : new Uri(Url);
}