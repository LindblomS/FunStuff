using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Order
{
    public interface IOrderRepository
    {
        IList<string> GetCondiments();
        IList<string> GetMainDishes();
    }
}
