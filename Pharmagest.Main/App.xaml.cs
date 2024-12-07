using Autofac;
using System.Windows;

namespace Pharmagest.Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer _container;

        public App()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _container = AutofacConfig.Configure();

            var mainWindow = _container.Resolve<MainWindow>();
            mainWindow.Show();
        }

    }
}
