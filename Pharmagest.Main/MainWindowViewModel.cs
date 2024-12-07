using Pharmagest.WPF;
using Pharmagest.WPF.Company.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pharmagest.Main
{
    public class MainWindowViewModel<UC> : BaseViewModel where UC : BaseViewModel
    {

        private UC _currentView;

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

    }
}
