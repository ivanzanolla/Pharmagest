using Newtonsoft.Json;
using System;

namespace Pharmagest.WebClient.Rest.Response
{
    public class VatNumberResponse
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; } = string.Empty;

        [JsonProperty("vatNumber")]
        public string VatNumber { get; set; } = string.Empty;

        [JsonProperty("requestDate")]
        public DateTime? RequestDate { get; set; }

        [JsonProperty("valid")]
        public bool IsValid { get; set; }

        [JsonProperty("requestIdentifier")]
        public string RequestIdentifier { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        [JsonProperty("traderName")]
        public string TraderName { get; set; } = string.Empty;

        [JsonProperty("traderStreet")]
        public string TraderStreet { get; set; } = string.Empty;

        [JsonProperty("traderPostalCode")]
        public string TraderPostalCode { get; set; } = string.Empty;

        [JsonProperty("traderCity")]
        public string TraderCity { get; set; } = string.Empty;

        [JsonProperty("traderCompanyType")]
        public string TraderCompanyType { get; set; } = string.Empty;

        [JsonProperty("traderNameMatch")]
        public string TraderNameMatch { get; set; } = string.Empty;

        [JsonProperty("traderStreetMatch")]
        public string TraderStreetMatch { get; set; } = string.Empty;

        [JsonProperty("traderPostalCodeMatch")]
        public string TraderPostalCodeMatch { get; set; } = string.Empty;

        [JsonProperty("traderCityMatch")]
        public string TraderCityMatch { get; set; } = string.Empty;

        [JsonProperty("traderCompanyTypeMatch")]
        public string TraderCompanyTypeMatch { get; set; } = string.Empty;
    }
}
