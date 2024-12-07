using Pharmagest.Interface.Database.Poco;
using System.Collections.Generic;

namespace Pharmagest.Interface.Database.Dao
{
    public interface ICompanyDao
    {
        IEnumerable<ICompany> GetCompanies();
        ICompany GetCompany(string countryCode, string vat);
        int InsertCompany(ICompany company);
        bool IsAlreadySaved(string countryCode, string vat);
        int UpdateCompany(ICompany company);
    }
}