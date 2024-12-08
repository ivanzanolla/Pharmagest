using Pharmagest.Dto.Company;
using Pharmagest.Message.Company;
using Pharmagest.WPF.Company.ViewModel;
using System;
using System.Globalization;
using System.Windows.Input;

namespace Pharmagest.WPF.Company.Command
{
    public class RequestSoapCommand : ICommand
    {
        private readonly UserControlViewModel _viewModel;

        public event EventHandler CanExecuteChanged;


        public RequestSoapCommand(UserControlViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var requestDto = new RequestVatDto { CountryCode = _viewModel.SelectedCountryCode, Vat = _viewModel.Vat };

            var responseVatDto = await _viewModel.WebClientContext.ExecuteStrategyAsync("WebSoapVatService", requestDto);


            if (!responseVatDto.IsValid)
            {
                _viewModel.SelectedCompany.RequestTime = responseVatDto.ErrorMessage;
                _viewModel.SelectedCompany.Vat = responseVatDto.ErrorMessage;
                _viewModel.SelectedCompany.Name = responseVatDto.ErrorMessage;
                _viewModel.SelectedCompany.CountryCode = string.Empty;
                _viewModel.SelectedCompany.Address = responseVatDto.ErrorMessage;
                return;
            }

            var companyDto = responseVatDto.Company;

            _viewModel.SelectedCompany.RequestTime = companyDto.RequestTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            _viewModel.SelectedCompany.Vat = companyDto.Vat;
            _viewModel.SelectedCompany.Name = companyDto.Name;
            _viewModel.SelectedCompany.CountryCode = companyDto.CountryCode;
            _viewModel.SelectedCompany.Address = companyDto.Address;



            var syncCompanyDbMessage = new SyncCompanyDbMessage { Dto = responseVatDto.Company };

            _viewModel.ObserverService.Publish(syncCompanyDbMessage);
        }

    }


}

