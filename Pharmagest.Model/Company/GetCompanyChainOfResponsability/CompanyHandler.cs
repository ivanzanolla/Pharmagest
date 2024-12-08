using Pharmagest.Dto.Company;
using System;

namespace Pharmagest.Model.Company.GetCompanyChainOfResponsability
{
    public abstract class CompanyHandler
    {
        protected CompanyHandler _nextHandler;

        public void SetNextHandler(CompanyHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract Tuple<CompanyDto, bool> Handle(CompanyDto companyDto);
    }
}
