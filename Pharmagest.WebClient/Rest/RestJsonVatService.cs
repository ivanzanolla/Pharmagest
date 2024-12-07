using Newtonsoft.Json;
using Pharmagest.Dto.Company;
using Pharmagest.WebClient.Rest.Request;
using Pharmagest.WebClient.Rest.Response;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pharmagest.WebClient.Rest
{
    public class RestJsonVatService : BaseVatWebClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = @"https://ec.europa.eu/taxation_customs/vies/rest-api/";

        public override string Name => nameof(RestJsonVatService);

        public RestJsonVatService()
        {

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_baseUrl),
            };
        }

        public override CompanyDto GetCompany(RequestVatDto requestVatDto)
        {
            if (requestVatDto.CountryCode == null)
                throw new ArgumentNullException(nameof(requestVatDto.CountryCode));
            if (requestVatDto.Vat == null)
                throw new ArgumentNullException(nameof(requestVatDto.Vat));

            var vatNumberRequest = new VatNumberRequest
            {
                CountryCode = requestVatDto.CountryCode,
                VatNumber = requestVatDto.Vat,
            };

            var response = CheckVatNumber(vatNumberRequest).GetAwaiter().GetResult();

            var dto = new CompanyDto
            {
                Address = response.Address,
                CountryCode = response.CountryCode,
                Name = response.Name,
                RequestTime = response.RequestDate ?? DateTime.Now,
                Vat = response.VatNumber
            };

            return dto;
        }




        private async Task<VatNumberResponse> CheckVatNumber(VatNumberRequest body)
        {
            string requestUri = "check-vat-number";
            var json = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage message = await _httpClient.PostAsync(requestUri, content);
            return await ParseContent<VatNumberResponse>(message);
        }

        private async Task<VatNumberResponse> CheckVatTestService(VatNumberRequest body)
        {
            string requestUri = "check-vat-test-service";
            var json = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage message = await _httpClient.PostAsync(requestUri, content);
            return await ParseContent<VatNumberResponse>(message);
        }


        private async Task<StatusResponse> CheckStatus()
        {
            string requestUri = "check-status";
            HttpResponseMessage message = await _httpClient.GetAsync(requestUri);
            return await ParseContent<StatusResponse>(message);
        }

        private static async Task<T> ParseContent<T>(HttpResponseMessage message) where T : class
        {
            if (message.IsSuccessStatusCode)
            {
                var messageStr = await message.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(messageStr);
                return result;
            }
            else
            {
                //ErrorResponse? errorResponseMessage = await message.Content.ReadFromJsonAsync<ErrorResponse>();
                //if (errorResponseMessage != null)
                //{
                //    throw new ViesSharpException(errorResponseMessage);
                //}

                //throw new ViesSharpException();
            }

            return null;
        }
    }
}
