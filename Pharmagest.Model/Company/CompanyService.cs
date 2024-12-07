using Pharmagest.Dto.Company;
using Pharmagest.Interface.Database.Dao;
using Pharmagest.Interface.ObserverManager;
using Pharmagest.Interface.Service;
using Pharmagest.Message.Company;
using Pharmagest.Model.Company.GetCompanyChainOfResponsability;
using Pharmagest.Model.Mapping;


namespace Pharmagest.Model.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyDao _companyDao;
        private readonly IObserverService _observerService;
        private UpdateCompanyInDatabaseHandler _handler;

        public CompanyService(ICompanyDao companyDao, IObserverService observerService)
        {
            _companyDao = companyDao;
            _observerService = observerService;
            InitChainOfResponsability();

            _observerService.Subscribe(OnSyncCompanyDb, "SyncCompanyDbMessage");
        }

        private void OnSyncCompanyDb(IBaseMessage message)
        {
            if (message.SystemName.Equals("SyncCompanyDbMessage"))
            {
                var msg = (SyncCompanyDbMessage)message;
                _handler.Handle(msg.Dto);
            }
        }

        private void InitChainOfResponsability()
        {
            var updateDbHandler = new UpdateCompanyInDatabaseHandler(_companyDao);
            var insertDbHandler = new InsertCompanyInDatabaseHandler(_companyDao);

            updateDbHandler.SetNextHandler(insertDbHandler);

            _handler = updateDbHandler;
        }

        public CompanyDto SyncCompanyDb(CompanyDto companyDto)
        {
            return _handler.Handle(companyDto);
        }

        public bool UpdateCompanyDb(CompanyDto companyDto)
        {

            var entity = companyDto.ToEntity();
            var rowsAffected = _companyDao.UpdateCompany(entity);

            return rowsAffected > 0;
        }

        public bool SaveCompanyDb(CompanyDto companyDto)
        {

            var entity = companyDto.ToEntity();
            var rowsAffected = _companyDao.InsertCompany(entity);

            return rowsAffected > 0;
        }



    }
}
