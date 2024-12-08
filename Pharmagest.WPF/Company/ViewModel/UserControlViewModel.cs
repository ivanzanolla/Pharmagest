using Pharmagest.Dto.Company;
using Pharmagest.Interface.ObserverManager;
using Pharmagest.Interface.WebClient;
using Pharmagest.Message.Company;
using Pharmagest.WPF.Company.Command;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace Pharmagest.WPF.Company.ViewModel
{
    public class UserControlViewModel : BaseViewModel
    {

        private readonly IWebClientContext _webClientContext;
        private readonly IObserverService _observerService;

        internal IWebClientContext WebClientContext => _webClientContext;
        internal IObserverService ObserverService => _observerService;

        internal ConcurrentDictionary<string, CompanyDto> PendingSyncCompanyDb;


        public RequestCommand RequestCmd { get; set; }

        public CompanyViewModel SelectedCompany { get; set; }

        public ObservableCollection<CountryViewModel> Countries { get; set; }

        public UserControlViewModel CurrentView { get; set; }

        public UserControlViewModel(IWebClientContext webClientContext, IObserverService observerService)
        {
            PendingSyncCompanyDb = new ConcurrentDictionary<string, CompanyDto>();
            SelectedCompany = new CompanyViewModel();
            CurrentView = this;
            RequestCmd = new RequestCommand(this);
            var countries = GetEuropeanUnionCountries();
            Countries = new ObservableCollection<CountryViewModel>(countries);
            _webClientContext = webClientContext;
            _observerService = observerService;


            ObserverService.Subscribe(OnSyncCompanyDbResponse, nameof(SyncCompanyDbResponse));
        }

        private void OnSyncCompanyDbResponse(IBaseMessage message)
        {
            if (!message.SystemName.Equals(nameof(SyncCompanyDbResponse)))
            {
                return;
            }

            if (message is SyncCompanyDbResponse syncCompanyDbResponse)
            {
                if (syncCompanyDbResponse.Ok)
                {
                    PendingSyncCompanyDb.TryRemove(syncCompanyDbResponse.Id, out _);
                }
                else
                {
                    PendingSyncCompanyDb.TryGetValue(syncCompanyDbResponse.Id, out CompanyDto companyDto);

                    if (companyDto == null)
                    {
                        return;
                    }
                    var messageBoxStr = $"{companyDto.Name} / CountryCode: {companyDto.CountryCode} / Vat: {companyDto.Vat}";
                    MessageBox.Show($"Unable to save {messageBoxStr}", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #region Properties
        private string _selectedCountryCode;
        public string SelectedCountryCode
        {
            get { return _selectedCountryCode; }
            set
            {
                if (_selectedCountryCode != value)
                {
                    _selectedCountryCode = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _vat;

        public string Vat
        {
            get { return _vat; }
            set
            {
                if (_vat != value)
                {
                    _vat = value.Trim();
                    OnPropertyChanged();
                }
            }
        }


        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                }
            }
        }


        #endregion


        private List<CountryViewModel> GetEuropeanUnionCountries()
        {
            var euCountryCodes = new List<string>
            {
                "AT", "BE", "BG", "CY", "CZ", "DE", "DK", "EE", /*"EL",*/ "ES", "FI", "FR",
                "HR", "HU", "IE", "IT", "LT", "LU", "LV", "MT", "NL", "PL", "PT", "RO",
                "SE", "SI", "SK"
            };

            var countries = new List<CountryViewModel>();
            foreach (var code in euCountryCodes)
            {
                var region = new RegionInfo(code);
                countries.Add(new CountryViewModel
                {
                    CountryCode = region.TwoLetterISORegionName,
                    Name = region.DisplayName
                });
            }


            countries.Add(new CountryViewModel { CountryCode = "EL", Name = "Greece" });

            countries = countries.OrderBy(c => c.Name).ToList();

            return countries;
        }

    }

}

