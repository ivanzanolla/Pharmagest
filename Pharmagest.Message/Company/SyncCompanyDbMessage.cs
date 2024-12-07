using Pharmagest.Dto.Company;

namespace Pharmagest.Message.Company
{
    public class SyncCompanyDbMessage : BaseMessage
    {

        public CompanyDto Dto { get; set; }

        public SyncCompanyDbMessage() : base(nameof(SyncCompanyDbMessage))
        {
        }
    }
}
