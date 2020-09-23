using Restaurant.Models;
using Restaurant.Order;
using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Restaurant.ViewModels
{
    public class CreateOrderViewModel : BaseViewModel, IOkOrCancel<IOrder>
    {
        private IOrder _order;
        private OrderItemViewModel _selectedOrderItem;
        private IList<string> _mainDishes;
        private readonly Guid _viewId;
        private readonly IOrderRepository _orderRepository;
        private readonly IWindowFactory _windowFactory;

        public CreateOrderViewModel(IOrderRepository orderRepository, IWindowFactory windowFactory)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _windowFactory = windowFactory ?? throw new ArgumentNullException(nameof(windowFactory));
            _order = new Order.Order();
            _mainDishes = GetMainDishes();
            _viewId = Guid.NewGuid();
            AddOrderItemCommand = new RelayCommand(execute => AddOrderItem(), canExcute => !string.IsNullOrEmpty(SelectedMainDish));
            RemoveOrderItemCommand = new RelayCommand(execute => RemoveOrderItem(), canExecute => _selectedOrderItem != null);
            OkCommand = new RelayCommand(execute => CreateOrder());
            CancelCommand = new RelayCommand(execute => CancelOrder());
        }

        public Guid ViewId => _viewId;
        public IOrder ReturnObject => _order;
        public string SelectedMainDish { get; set; }
        public bool IsCanceled { get; private set; }
        public ObservableCollection<OrderItemViewModel> OrderItems => GetOrderItems();
        public IList<string> MainDishes => _mainDishes;
        public OrderItemViewModel SelectedOrderItem 
        { 
            get { return _selectedOrderItem; }
            set { _selectedOrderItem = value; NotifyPropertyChanged(); }
        }

        public ICommand AddOrderItemCommand { get; set; }
        public ICommand RemoveOrderItemCommand { get; set; }
        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private void AddOrderItem()
        {
            IOrderItem orderItem = null;

            switch (SelectedMainDish)
            {
                case "Steak":
                    orderItem = new Steak();
                    break;
                case "Fish":
                    orderItem = new Fish();
                    break;
            }

            if (orderItem != null)
            {
                var addCondimentsWindow = _windowFactory.GetAddCondimentsWindow();
                addCondimentsWindow.Window.ShowDialog();
                var vm = (IOkOrCancel<IEnumerable<CondimentViewModel>>)addCondimentsWindow.ViewModel;

                if (vm.IsCanceled)
                    return;

                if (vm.ReturnObject.Any())
                {
                    foreach (var condiment in vm.ReturnObject.Where(c => c.Checked))
                    {
                        orderItem = CondimentHelper.AddCondimentToOrderItem(orderItem, condiment.Name);
                    }
                }
            }

            _order.AddOrderItem(orderItem);
            NotifyPropertyChanged(nameof(OrderItems));
        }

        private void RemoveOrderItem()
        {
            _order.RemoveOrderItem(_selectedOrderItem.OrderItem);
            SelectedOrderItem = null;
            NotifyPropertyChanged(nameof(OrderItems));
        }

        private void CreateOrder()
        {
            IsCanceled = false;
            WindowManager.CloseWindow(_viewId);
        }

        private void CancelOrder()
        {
            IsCanceled = true;
            _order = null;
            WindowManager.CloseWindow(_viewId);
        }

        private IList<string> GetMainDishes()
        {
            return _orderRepository.GetMainDishes();
        }

        private ObservableCollection<OrderItemViewModel> GetOrderItems()
        {
            var orderItems = new ObservableCollection<OrderItemViewModel>();

            foreach (var item in _order.GetOrderItems())
            {
                orderItems.Add(new OrderItemViewModel(item));
            }

            return orderItems;
        }
    }
}
