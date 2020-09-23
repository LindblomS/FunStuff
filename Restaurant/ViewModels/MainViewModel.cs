using Restaurant.Models;
using Restaurant.Order;
using Restaurant.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Restaurant.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IWindowFactory _windowFactory;
        private ObservableCollection<OrderMakerViewModel> _orders;

        public MainViewModel(IWindowFactory windowFactory)
        {
            _orders = new ObservableCollection<OrderMakerViewModel>();
            CreateOrderMainCommand = new RelayCommand(execute => CreateOrder());
            _windowFactory = windowFactory ?? throw new System.ArgumentNullException(nameof(windowFactory));
        }

        public ObservableCollection<OrderMakerViewModel> Orders => _orders;
        public ICommand CreateOrderMainCommand { get; private set; }

        private void CreateOrder()
        {
            IOrder order = null;
            var createOrderWindow = _windowFactory.GetCreateOrderWindow();
            createOrderWindow.Window.ShowDialog();
            var vm = (IOkOrCancel<IOrder>)createOrderWindow.ViewModel;

            if (vm.IsCanceled)
                return;

            order = vm.ReturnObject;
            var orderMaker = new OrderMakerViewModel(order, new OrderMaker.OrderMaker());
            Task.Run(() => orderMaker.MakeOrderAsync());
            _orders.Add(orderMaker);
            NotifyPropertyChanged(nameof(Orders));
        }
    }
}
