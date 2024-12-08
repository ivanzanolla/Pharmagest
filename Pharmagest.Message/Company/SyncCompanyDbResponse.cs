namespace Pharmagest.Message.Company
{
    public class SyncCompanyDbResponse : BaseMessage
    {
        public bool Ok { get; set; }

        public SyncCompanyDbResponse(string id) : base(nameof(SyncCompanyDbResponse), id)
        {
        }
    }


}
