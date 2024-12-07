using Pharmagest.Dto.Company;

namespace Pharmagest.Model.Company.GetCompanyChainOfResponsability
{
    public abstract class CompanyHandler
    {
        protected CompanyHandler _nextHandler;

        public void SetNextHandler(CompanyHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract CompanyDto Handle(CompanyDto companyDto);
    }
}
