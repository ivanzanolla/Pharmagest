using Pharmagest.Dto.Company;
using Pharmagest.Message.Company;
using Pharmagest.WPF.Company.Extension;
using Pharmagest.WPF.Company.ViewModel;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Pharmagest.WPF.Company.Command
{
    public class RequestCommand : ICommand
    {
        private readonly UserControlViewModel _viewModel;

        public event EventHandler CanExecuteChanged;


        public RequestCommand(UserControlViewModel viewModel)
        {
            _viewModel = viewModel;

            WeakEventManager<UserControlViewModel, PropertyChangedEventArgs>
             .AddHandler(_viewModel, nameof(_viewModel.PropertyChanged), OnViewModelPropertyChanged);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsBusy"))
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }


        public bool CanExecute(object parameter)
        {
            return !_viewModel.IsBusy;
        }

        public async void Execute(object parameter)
        {
            _viewModel.IsBusy = true;

            var strategy = parameter.ToString();

            var requestDto = new RequestVatDto { CountryCode = _viewModel.SelectedCountryCode, Vat = _viewModel.Vat };

            var responseVatDto = await _viewModel.WebClientContext.ExecuteStrategyAsync(strategy, requestDto);

            if (!responseVatDto.IsValid)
            {
                _viewModel.SelectedCompany.SetError(responseVatDto.ErrorMessage);
                _viewModel.IsBusy = false;
                return;
            }

            _viewModel.SelectedCompany.ToUpdate(responseVatDto.Company);

            var syncCompanyDbMessage = new SyncCompanyDbRequest { Dto = responseVatDto.Company };

            _viewModel.ObserverService.Publish(syncCompanyDbMessage);

            _viewModel.PendingSyncCompanyDb.TryAdd(syncCompanyDbMessage.Id, responseVatDto.Company);

            _viewModel.IsBusy = false;

        }



    }


}

