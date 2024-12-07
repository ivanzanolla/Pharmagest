using System;

namespace Pharmagest.Interface.Database.Poco
{
    public interface ICompany
    {
        string Address { get; set; }
        string CountryCode { get; set; }
        string Id { get; set; }
        string Name { get; set; }
        DateTime RequestTime { get; set; }
        string Vat { get; set; }
    }
}