using Pharmagest.Dto.Company;
using Pharmagest.Interface.Database.Dao;
using Pharmagest.Model.Mapping;
using System;

namespace Pharmagest.Model.Company.GetCompanyChainOfResponsability
{
    public class InsertCompanyInDatabaseHandler : CompanyHandler
    {
        private readonly ICompanyDao _companyDao;

        public InsertCompanyInDatabaseHandler(ICompanyDao companyDao)
        {
            _companyDao = companyDao;
        }

        public override Tuple<CompanyDto, bool> Handle(CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                return null;
            }

            var entity = companyDto.ToEntity();
            var insertRows = _companyDao.InsertCompany(entity);

            return Tuple.Create(companyDto, insertRows == 1);

        }
    }
}
