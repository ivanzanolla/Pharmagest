using Newtonsoft.Json;

namespace Pharmagest.WebClient.Rest.Response
{
    public class StatusResponse
    {
        [JsonProperty("vow")]
        public Vow Vow { get; set; }

        [JsonProperty("countries")]
        public Country[] Countries { get; set; }
    }
}
