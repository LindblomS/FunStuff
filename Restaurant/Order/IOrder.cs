using System.Collections.Generic;

namespace Restaurant.Order
{
    public interface IOrder
    {
        void AddOrderItem(IOrderItem item);
        void RemoveOrderItem(IOrderItem item);
        IList<IOrderItem> GetOrderItems();
    }
}
