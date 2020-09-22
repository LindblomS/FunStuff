using System;

namespace Restaurant.ViewModels
{
    public class OrderItemViewModel : BaseViewModel
    {
        private readonly IOrderItem _orderItem;

        public OrderItemViewModel(IOrderItem orderItem)
        {
            _orderItem = orderItem ?? throw new ArgumentNullException(nameof(orderItem));
        }

        public IOrderItem OrderItem => _orderItem;
        public string Description => _orderItem.GetDescription();
        public int Price => _orderItem.GetPrice();
    }
}
