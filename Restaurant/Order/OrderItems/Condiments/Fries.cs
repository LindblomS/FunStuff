namespace Restaurant.Order.Condiments
{
    public class Fries : Condiment
    {
        public Fries(IOrderItem food)
            : base(food)
        {
            _name = "Fries";
            _secondsToMake = 2;
            _price = 5;
        }
    }
}
