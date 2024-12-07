using Newtonsoft.Json;

namespace Pharmagest.WebClient.Rest.Response
{
    public class Country
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; } = string.Empty;

        [JsonProperty("availability")]
        public string Availability { get; set; } = string.Empty;

    }
}
