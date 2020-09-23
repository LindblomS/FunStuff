using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Restaurant.Models
{
    public class WindowWithViewModel
    {
        public WindowWithViewModel(BaseViewModel vm, Window window)
        {
            ViewModel = vm ?? throw new ArgumentNullException(nameof(vm));
            Window = window ?? throw new ArgumentNullException(nameof(window));
            Window.DataContext = ViewModel;
        }

        public BaseViewModel ViewModel { get; }
        public Window Window { get; }
    }
}
