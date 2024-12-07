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

        public void Execute(object parameter)
        {
            var requestDto = new RequestVatDto { CountryCode = _viewModel.SelectedCountryCode, Vat = _viewModel.Vat };

            var dto = _viewModel.WebClientContext.ExecuteStrategy("WebSoapVatService", requestDto);

            if (dto == null)
            {
                _viewModel.SelectedCompany.RequestTime = string.Empty;
                _viewModel.SelectedCompany.Vat = string.Empty;
                _viewModel.SelectedCompany.Name = string.Empty;
                _viewModel.SelectedCompany.CountryCode = string.Empty;
                _viewModel.SelectedCompany.Address = string.Empty;
                //TODO mettere errore
                return;
            }
            _viewModel.SelectedCompany.RequestTime = dto.RequestTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            _viewModel.SelectedCompany.Vat = dto.Vat;
            _viewModel.SelectedCompany.Name = dto.Name;
            _viewModel.SelectedCompany.CountryCode = dto.CountryCode;
            _viewModel.SelectedCompany.Address = dto.Address;



            var syncCompanyDbMessage = new SyncCompanyDbMessage { Dto = dto };

            _viewModel.ObserverService.Publish(syncCompanyDbMessage);
        }

    }


}

