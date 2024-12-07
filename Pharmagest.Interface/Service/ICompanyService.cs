using Pharmagest.Dto.Company;

namespace Pharmagest.Interface.Service
{
    public interface ICompanyService
    {
        CompanyDto SyncCompanyDb(CompanyDto companyDto);
        bool SaveCompanyDb(CompanyDto companyDto);
        bool UpdateCompanyDb(CompanyDto companyDto);
    }
}