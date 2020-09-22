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
    public class CreateOrderViewModel : BaseViewModel, IRequireViewIdentification
    {
        private IOrder _order;
        private OrderItemViewModel _selectedOrderItem;
        private IList<string> _mainDishes;
        private readonly Guid _viewId;

        public CreateOrderViewModel()
        {
            _order = new Order.Order();
            _mainDishes = GetMainDishes();
            _viewId = Guid.NewGuid();
            AddOrderItemCommand = new RelayCommand(execute => AddOrderItem(), canExcute => !string.IsNullOrEmpty(SelectedMainDish));
            RemoveOrderItemCommand = new RelayCommand(execute => RemoveOrderItem(), canExecute => _selectedOrderItem != null);
            CreateOrderCommand = new RelayCommand(execute => CreateOrder());
            CancelOrderCommand = new RelayCommand(execute => CancelOrder());
        }

        public Guid ViewId => _viewId;
        public IOrder Order => _order;
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
        public ICommand CreateOrderCommand { get; set; }
        public ICommand CancelOrderCommand { get; set; }

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
                var vm = new AddCondimentsViewModel();
                var view = new AddCondimentsWindow();
                view.DataContext = vm;
                view.ShowDialog();

                if (vm.IsCanceled)
                    return;

                if (vm.Condiments.Any())
                {
                    foreach (var condiment in vm.Condiments.Where(c => c.Checked))
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
            return new List<string>
            {
                "Steak",
                "Fish"
            };
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
