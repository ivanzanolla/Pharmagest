using Pharmagest.Dto.Company;
using System.Threading.Tasks;

namespace Pharmagest.Interface.WebClient
{
    public interface IVatWebClient
    {
        string Name { get; }

        Task<ResponseVatDto> GetCompanyAsync(RequestVatDto requestVatDto);
    }
}