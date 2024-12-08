using Pharmagest.Dto.Company;

namespace Pharmagest.Message.Company
{
    public class SyncCompanyDbRequest : BaseMessage
    {

        public CompanyDto Dto { get; set; }

        public SyncCompanyDbRequest() : base(nameof(SyncCompanyDbRequest))
        {
        }
    }
}
