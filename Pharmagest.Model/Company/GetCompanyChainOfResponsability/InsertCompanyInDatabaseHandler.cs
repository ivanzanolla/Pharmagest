using Pharmagest.Dto.Company;
using Pharmagest.Interface.Database.Dao;
using Pharmagest.Model.Mapping;

namespace Pharmagest.Model.Company.GetCompanyChainOfResponsability
{
    public class InsertCompanyInDatabaseHandler : CompanyHandler
    {
        private readonly ICompanyDao _companyDao;

        public InsertCompanyInDatabaseHandler(ICompanyDao companyDao)
        {
            _companyDao = companyDao;
        }

        public override CompanyDto Handle(CompanyDto companyDto)
        {

            if (companyDto == null)
            {
                return null;
            }

            //TODO fare check se inserisce le righe?
            var entity = companyDto.ToEntity();
            var insertRows = _companyDao.InsertCompany(entity);

            return companyDto;

        }
    }
}
