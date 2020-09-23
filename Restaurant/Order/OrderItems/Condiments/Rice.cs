namespace Restaurant.Order.Condiments
{
    public class Rice : Condiment
    {
        public Rice(IOrderItem food)
            : base(food)
        {
            _name = "Rice";
            _secondsToMake = 5;
            _price = 3;
        }
    }
}
