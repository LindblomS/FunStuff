using Restaurant.Order.Condiments;

namespace Restaurant.Models
{
    public static class CondimentHelper
    {
        public static IOrderItem AddCondimentToOrderItem(IOrderItem orderItem, string condimentName)
        {
            switch (condimentName)
            {
                case "Fries":
                    return new Fries(orderItem);
                case "Rice":
                    return new Rice(orderItem);
            }

            return orderItem;
        }
    }
}
