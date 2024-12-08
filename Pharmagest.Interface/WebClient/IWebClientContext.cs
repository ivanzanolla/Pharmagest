using Pharmagest.Dto.Company;
using System.Threading.Tasks;

namespace Pharmagest.Interface.WebClient
{
    public interface IWebClientContext
    {
        Task<ResponseVatDto> ExecuteStrategyAsync(string engineName, RequestVatDto requestVatDto);
    }
}