using Pharmagest.Dto.Company;

namespace Pharmagest.Interface.WebClient
{
    public interface IWebClientContext
    {
        CompanyDto ExecuteStrategy(string engineName, RequestVatDto requestVatDto);
    }
}