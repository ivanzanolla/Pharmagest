using Pharmagest.Dto.Company;
using Pharmagest.WPF.Company.ViewModel;
using System;
using System.Globalization;

namespace Pharmagest.WPF.Company.Extension
{
    internal static class ViewModelExtension
    {

        internal static void ToUpdate(this CompanyViewModel companyViewModel, CompanyDto companyDto)
        {
            if (companyDto == null)
                throw new ArgumentNullException(nameof(companyDto));

            companyViewModel.RequestTime = companyDto.RequestTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            companyViewModel.Vat = companyDto.Vat;
            companyViewModel.Name = companyDto.Name;
            companyViewModel.CountryCode = companyDto.CountryCode;
            companyViewModel.Address = companyDto.Address;
        }


        internal static void SetError(this CompanyViewModel companyViewModel, string error)
        {
            companyViewModel.RequestTime = error;
            companyViewModel.Vat = error;
            companyViewModel.Name = error;
            companyViewModel.CountryCode = error;
            companyViewModel.Address = error;
        }

    }


}

