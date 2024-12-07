using Newtonsoft.Json;

namespace Pharmagest.WebClient.Rest.Request
{
    public class VatNumberRequest
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; } = string.Empty;

        [JsonProperty("vatNumber")]
        public string VatNumber { get; set; } = string.Empty;

        [JsonProperty("requesterMemberStateCode")]
        public string RequesterMemberStateCode { get; set; } = string.Empty;

        [JsonProperty("requesterNumber")]
        public string RequesterNumber { get; set; } = string.Empty;

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
    }
}
