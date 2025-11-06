using Microsoft.Extensions.DependencyInjection;
using MyWorkoutLog.MVVM.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

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
