using Restaurant.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.OrderMaker
{
    public class OrderMaker : IOrderMaker
    {
        private int _progress;

        public OrderMaker()
        {
        }

        public int Progress => _progress;
        public Action OrderItemDoneCallBack { get; set; }

        public async Task MakeOrderAsync(IOrder order)
        {
            _progress = 0;
            var tasks = new List<Task>();

            foreach (var item in order.GetOrderItems())
            {
                tasks.Add(Task.Run(() => { Thread.Sleep(item.SecondsToMake() * 1000); }));
            }

            var processingTasks = tasks.Select(AwaitAndProcessAsync).ToList();

            await Task.WhenAll(processingTasks);
        }

        private async Task AwaitAndProcessAsync(Task task)
        {
            await task;
            _progress++;
            OrderItemDoneCallBack?.Invoke();
        }
    }
}
