using Pharmagest.Dto.Company;
using Pharmagest.Interface.WebClient;

namespace Pharmagest.WebClient
{
    public abstract class BaseVatWebClient : IVatWebClient
    {

        public abstract string Name { get; }
        public abstract CompanyDto GetCompany(RequestVatDto requestVatDto);

    }
}
