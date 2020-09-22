using System.Collections.Generic;

namespace Restaurant.Order
{
    public class Order : IOrder
    {
        private IList<IOrderItem> _orderItems;

        public Order()
        {
            _orderItems = new List<IOrderItem>();
        }

        public void AddOrderItem(IOrderItem item)
        {
            _orderItems.Add(item);
        }
        public void RemoveOrderItem(IOrderItem item)
        {
            _orderItems.Remove(item);
        }

        public IList<IOrderItem> GetOrderItems()
        {
            return _orderItems;
        }
    }
}
