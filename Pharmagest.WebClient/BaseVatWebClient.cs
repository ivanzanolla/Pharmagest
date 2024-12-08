using Pharmagest.Dto.Company;
using Pharmagest.Interface.WebClient;
using System.Threading.Tasks;

namespace Pharmagest.WebClient
{
    public abstract class BaseVatWebClient : IVatWebClient
    {

        public abstract string Name { get; }
        public abstract Task<ResponseVatDto> GetCompanyAsync(RequestVatDto requestVatDto);

    }
}
