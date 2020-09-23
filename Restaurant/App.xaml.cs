using Microsoft.Extensions.DependencyInjection;
using Restaurant.Models;
using Restaurant.Order;
using Restaurant.ViewModels;
using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var windowFactory = ServiceProvider.GetRequiredService<IWindowFactory>();
            var mainWindow = windowFactory.GetMainWindow();
            mainWindow.Window.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IWindowFactory, WindowFactory>();
            services.AddTransient<AddCondimentsViewModel>();
            services.AddTransient<CreateOrderViewModel>();
            services.AddTransient<AddCondimentsWindow>();
            services.AddTransient<CreateOrderWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainWindow>();
        }
    }
}
