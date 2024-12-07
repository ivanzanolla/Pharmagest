using Newtonsoft.Json;

namespace Pharmagest.WebClient.Rest.Response
{
    public class Vow
    {

        [JsonProperty("available")]
        public bool IsAvailable { get; set; }
    }
}
