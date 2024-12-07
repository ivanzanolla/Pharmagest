using Pharmagest.Dto.Company;
using Pharmagest.Interface.Database.Poco;
using System;

namespace Pharmagest.Model.Mapping
{
    public static class CompanyMapping
    {

        internal static CompanyDto ToDto(this ICompany company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                CountryCode = company.CountryCode,
                Vat = company.Vat,
                RequestTime = company.RequestTime,
                Address = company.Address
            };
        }


        internal static Entity.Company ToEntity(this CompanyDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return new Entity.Company
            {
                Id = dto.Id,
                Name = dto.Name,
                CountryCode = dto.CountryCode,
                Vat = dto.Vat,
                RequestTime = dto.RequestTime,
                Address = dto.Address
            };
        }

    }
}
