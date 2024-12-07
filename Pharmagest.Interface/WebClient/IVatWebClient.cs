using Pharmagest.Dto.Company;

namespace Pharmagest.Interface.WebClient
{
    public interface IVatWebClient
    {
        string Name { get; }

        CompanyDto GetCompany(RequestVatDto requestVatDto);
    }
}