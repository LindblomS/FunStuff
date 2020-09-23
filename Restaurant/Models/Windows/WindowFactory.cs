using Restaurant.ViewModels;
using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Restaurant.Models
{
    public class WindowFactory : IWindowFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public WindowFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public WindowWithViewModel GetAddCondimentsWindow()
        {
            var vm = _serviceProvider.GetService(typeof(AddCondimentsViewModel));
            var window = _serviceProvider.GetService(typeof(AddCondimentsWindow));
            return new WindowWithViewModel((BaseViewModel)vm, (Window)window);
        }

        public WindowWithViewModel GetCreateOrderWindow()
        {
            var vm = _serviceProvider.GetService(typeof(CreateOrderViewModel));
            var window = _serviceProvider.GetService(typeof(CreateOrderWindow));
            return new WindowWithViewModel((BaseViewModel)vm, (Window)window);
        }

        public WindowWithViewModel GetMainWindow()
        {
            var vm = _serviceProvider.GetService(typeof(MainViewModel));
            var window = _serviceProvider.GetService(typeof(MainWindow));
            return new WindowWithViewModel((BaseViewModel)vm, (Window)window);
        }
    }
}
