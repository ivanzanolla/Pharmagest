using Pharmagest.WPF;

namespace Pharmagest.Main
{
    public class MainWindowViewModel<UC> : BaseViewModel where UC : BaseViewModel
    {

        private UC _currentView;
        private string _header;

        public MainWindowViewModel(UC currentView)
        {
            CurrentView = currentView;
        }

        public UC CurrentView
        {
            get { return _currentView; }
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    //WeakEventManager<UC, PropertyChangedEventArgs>.AddHandler(CurrentView, nameof(CurrentView.PropertyChanged), OnPropertyChanged);
                    OnPropertyChanged();
                }
            }
        }


        public string Header
        {
            get { return _header; }
            set
            {
                if (value != _header)
                {
                    _header = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
