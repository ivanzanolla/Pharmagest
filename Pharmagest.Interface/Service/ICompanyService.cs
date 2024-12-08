using Pharmagest.Dto.Company;
using System;

namespace Pharmagest.Interface.Service
{
    public interface ICompanyService
    {
        Tuple<CompanyDto, bool> SyncCompanyDb(CompanyDto companyDto);
        bool SaveCompanyDb(CompanyDto companyDto);
        bool UpdateCompanyDb(CompanyDto companyDto);
    }
}