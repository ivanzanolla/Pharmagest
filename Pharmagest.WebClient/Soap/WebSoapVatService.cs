using Pharmagest.Dto.Company;
using Pharmagest.WebClient.Rest;
using System;
using System.ServiceModel;

namespace Pharmagest.WebClient.Soap
{
    public class WebSoapVatService : BaseVatWebClient
    {
        public override string Name => nameof(WebSoapVatService);

        private static readonly BasicHttpBinding _binding = new BasicHttpBinding();
        private static readonly EndpointAddress _endpoint = new EndpointAddress("http://ec.europa.eu/taxation_customs/vies/services/checkVatService");

        public override CompanyDto GetCompany(RequestVatDto requestVatDto)
        {
            if (requestVatDto.CountryCode == null)
                throw new ArgumentNullException(nameof(requestVatDto.CountryCode));
            if (requestVatDto.Vat == null)
                throw new ArgumentNullException(nameof(requestVatDto.Vat));

            var client = new SoapVatService.checkVatPortTypeClient(_binding, _endpoint);
            var countryCode = requestVatDto.CountryCode;
            var vatNumber = requestVatDto.Vat;

            var requestDateString = client.checkVat(ref countryCode, ref vatNumber, out bool valid, out string name, out string address);

            if (!valid)
            {
                return null;
            }
            var requestTime = DateTime.Parse(requestDateString);
            if (valid)
            {
                return new CompanyDto
                {
                    Address = address,
                    CountryCode = countryCode,
                    Vat = vatNumber,
                    Name = name,
                    RequestTime = requestTime,
                };
            }

            return null;

        }
    }
}
