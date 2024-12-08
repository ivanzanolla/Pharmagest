using Pharmagest.Dto.Company;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Pharmagest.WebClient.Soap
{
    public class WebSoapVatService : BaseVatWebClient
    {
        public override string Name => nameof(WebSoapVatService);

        private static readonly BasicHttpBinding _binding = new BasicHttpBinding();
        private static readonly EndpointAddress _endpoint = new EndpointAddress("http://ec.europa.eu/taxation_customs/vies/services/checkVatService");

        public override async Task<ResponseVatDto> GetCompanyAsync(RequestVatDto requestVatDto)
        {
            if (requestVatDto.CountryCode == null)
                throw new ArgumentNullException(nameof(requestVatDto.CountryCode));
            if (requestVatDto.Vat == null)
                throw new ArgumentNullException(nameof(requestVatDto.Vat));

            var client = new SoapVatService.checkVatPortTypeClient(_binding, _endpoint);
            var countryCode = requestVatDto.CountryCode;
            var vatNumber = requestVatDto.Vat;

            try
            {
                var checkVatResponse = await client.checkVatAsync(countryCode, vatNumber);
                var body = checkVatResponse.Body;

                if (!body.valid)
                {
                    return new ResponseVatDto
                    {
                        IsValid = false,
                        ErrorMessage = "Not valid"
                    };
                }

                var validRequestDateTime = DateTime.TryParse(body.requestDate, out DateTime requestTime);

                var companyDto = new CompanyDto
                {
                    Address = body.address,
                    CountryCode = body.countryCode,
                    Vat = body.vatNumber,
                    Name = body.name,
                    RequestTime = validRequestDateTime ? requestTime : DateTime.UtcNow,
                };

                return new ResponseVatDto
                {
                    Company = companyDto,
                    IsValid = true,
                    ErrorMessage = string.Empty
                };
            }
            catch (Exception ex)
            {

                return new ResponseVatDto
                {
                    IsValid = false,
                    ErrorMessage = ex.Message
                };
            }




        }
    }
}
