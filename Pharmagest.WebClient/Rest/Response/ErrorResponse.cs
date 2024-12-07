using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace Pharmagest.WebClient.Rest.Response
{
    public class ErrorResponse
    {
        [JsonProperty("actionSucceed")]
        public bool IsActionSucceeded { get; set; }

        [JsonProperty("errorWrappers")]
        public ErrorWrapper[] ErrorWrappers { get; set; }
    }
}
