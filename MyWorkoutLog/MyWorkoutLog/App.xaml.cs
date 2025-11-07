using Microsoft.Extensions.DependencyInjection;
using MyWorkoutLog.Core;
using MyWorkoutLog.MVVM.ViewModels;
using MyWorkoutLog.Services;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;

namespace MyWorkoutLog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>(serviceProvider => new MainWindow
            {
                DataContext = serviceProvider.GetRequiredService<MainviewModel>()
            });
            services.AddSingleton<MainviewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<AccountViewModel>();
            services.AddSingleton<ExercisesViewModel>();
            services.AddSingleton<HistoryViewModel>();
            services.AddSingleton<TemplatesViewModel>();

            // add navigation service defined in NavigationService.cs
            services.AddSingleton<INavigationService, Services.NavigationService>();

            // register the factory function for returning or creating the viewmodel using service provider and navigationservice
            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

            // create service provider containing services added to the IServiceCollcetion services
            _serviceProvider = services.BuildServiceProvider();
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
