using Restaurant.Order;
using Restaurant.OrderMaker;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    public class OrderMakerViewModel : BaseViewModel
    {
        private IOrder _order;
        private IOrderMaker _orderMaker;
        private int _totalPrice;

        public OrderMakerViewModel(IOrder order, IOrderMaker orderMaker)
        {
            _order = order ?? throw new ArgumentNullException(nameof(order));
            _orderMaker = orderMaker ?? throw new ArgumentNullException(nameof(orderMaker));
            _orderMaker.OrderItemDoneCallBack = () => UpdateProgress();
            SetTotalPrice();
        }

        private void UpdateProgress()
        {
            Progress = _orderMaker.Progress;
            NotifyPropertyChanged(nameof(Progress));
        }

        public int Progress { get; set; }
        public int OrderItemsCount => _order.GetOrderItems().Count;
        public int TotalPrice => _totalPrice;
        public string ElapsedTime { get; set; }

        public async Task MakeOrderAsync()
        {
            await _orderMaker.MakeOrderAsync(_order);
        }

        private void SetTotalPrice()
        {
            var items = _order.GetOrderItems().Select(x => x.GetPrice());

            if (items.Any())
                _totalPrice = items.Aggregate((sum, value) => sum += value);
        }
    }
}
