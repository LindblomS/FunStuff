using Restaurant.Order;
using System;
using System.Threading.Tasks;

namespace Restaurant.OrderMaker
{
    public interface IOrderMaker
    {
        Task MakeOrderAsync(IOrder order);
        int Progress { get; }
        Action OrderItemDoneCallBack { get; set; }
    }
}
