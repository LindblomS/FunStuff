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
        private ObservableCollection<OrderMakerViewModel> _orders;

        public MainViewModel()
        {
            _orders = new ObservableCollection<OrderMakerViewModel>();
            CreateOrderMainCommand = new RelayCommand(execute => CreateOrder());
        }


        public ObservableCollection<OrderMakerViewModel> Orders => _orders;
        public ICommand CreateOrderMainCommand { get; private set; }

        private void CreateOrder()
        {
            IOrder order = null;
            var vm = new CreateOrderViewModel();
            var window = new CreateOrderWindow();
            window.DataContext = vm;
            window.ShowDialog();

            if (vm.IsCanceled)
                return;

            order = vm.Order;
            var orderMaker = new OrderMakerViewModel(order, new OrderMaker.OrderMaker());
            Task.Run(() => orderMaker.MakeOrderAsync());
            _orders.Add(orderMaker);
            NotifyPropertyChanged(nameof(Orders));
        }
    }
}
