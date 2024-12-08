using Autofac;
using Pharmagest.Db.Dao;
using Pharmagest.Interface.Database.Dao;
using Pharmagest.Interface.Service;
using Pharmagest.Model.Company;
using IContainer = Autofac.IContainer;
using Pharmagest.WPF.Company.ViewModel;
using Pharmagest.WPF.Company.View;
using Pharmagest.WebClient.Soap;
using Pharmagest.WebClient.Rest;
using Pharmagest.WebClient;
using Pharmagest.Interface.WebClient;
using Pharmagest.Interface.ObserverManager;
using Pharmagest.Observer;

namespace Pharmagest.Main
{

    public class AutofacConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            #region Services
            builder.RegisterType<ObserverService>().As<IObserverService>().SingleInstance();
            builder.RegisterType<CompanyService>().As<ICompanyService>().SingleInstance();

            // faccio istanziare i servizi che devono sempre rimanere attivi
            builder.RegisterBuildCallback(c =>
            {
                c.Resolve<IObserverService>();
                c.Resolve<ICompanyService>();
            });

            builder.RegisterType<CompanyDao>().As<ICompanyDao>();
            builder.RegisterType<RestJsonVatService>().As<IVatWebClient>();
            builder.RegisterType<WebSoapVatService>().As<IVatWebClient>();
            builder.RegisterType<WebClientContext>().As<IWebClientContext>();
            #endregion

            #region UI
            builder.Register(ctx =>
            {
                var webClientContext = ctx.Resolve<IWebClientContext>();
                var observerService = ctx.Resolve<IObserverService>();
                return new UserControlViewModel(webClientContext, observerService);
            }).AsSelf();

            builder.RegisterType<UserControlVatCompany>()
                   .OnActivated(e =>
                       e.Instance.DataContext = e.Context.Resolve<UserControlViewModel>()
                       );


            builder.Register(ctx =>
            {
                var configService = ctx.Resolve<UserControlViewModel>();
                var mainWindowViewModel = new MainWindowViewModel<UserControlViewModel>(configService);
                mainWindowViewModel.Header = "Check vat";
                return mainWindowViewModel;
            }).AsSelf();


            builder.RegisterType<MainWindow>()
                   .OnActivated(e =>
                       e.Instance.DataContext = e.Context.Resolve<MainWindowViewModel<UserControlViewModel>>()
                       );

            #endregion

            return builder.Build();
        }
    }

}
