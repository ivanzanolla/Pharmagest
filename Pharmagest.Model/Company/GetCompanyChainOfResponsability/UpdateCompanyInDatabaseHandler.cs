using Pharmagest.Dto.Company;
using Pharmagest.Interface.Database.Dao;
using Pharmagest.Model.Mapping;
using System;

namespace Pharmagest.Model.Company.GetCompanyChainOfResponsability
{
    public class UpdateCompanyInDatabaseHandler : CompanyHandler
    {
        private readonly ICompanyDao _companyDao;

        public UpdateCompanyInDatabaseHandler(ICompanyDao companyDao)
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

            if (_companyDao.IsAlreadySaved(companyDto.CountryCode, companyDto.Vat))
            {
                var updatedRows = _companyDao.UpdateCompany(entity);
                return Tuple.Create(companyDto, updatedRows == 1);
            }
            else
            {
                return _nextHandler?.Handle(companyDto);
            }
        }
    }
}
