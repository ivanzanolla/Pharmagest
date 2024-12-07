using Pharmagest.Interface.Database.Poco;
using System;

namespace Pharmagest.Entity
{
    public class Company : ICompany
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Vat { get; set; }
        public DateTime RequestTime { get; set; }
        public string Address { get; set; }
    }
}
