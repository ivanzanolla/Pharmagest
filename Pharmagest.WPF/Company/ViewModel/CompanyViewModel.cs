using System;

namespace Pharmagest.WPF.Company.ViewModel
{
    public class CompanyViewModel : BaseViewModel
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
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
                    _vat = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _countryCode;
        public string CountryCode
        {
            get { return _countryCode; }
            set
            {
                if (_countryCode != value)
                {
                    _countryCode = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _requestTime;
        public string RequestTime
        {
            get { return _requestTime; }
            set
            {
                if (_requestTime != value)
                {
                    _requestTime = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
