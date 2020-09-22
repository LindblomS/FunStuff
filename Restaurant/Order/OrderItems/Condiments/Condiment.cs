namespace Restaurant
{
    public abstract class Condiment : IOrderItem
    {
        private readonly IOrderItem _order;
        protected string _name;
        protected int _secondsToMake;
        protected int _price;

        public Condiment(IOrderItem food)
        {
            _order = food;
        }

        public string Name => _name;

        public string GetDescription()
        {
            return $"{_order.GetDescription()}, {_name}";
        }

        public int SecondsToMake()
        {
            return _order.SecondsToMake() + _secondsToMake;
        }

        public int GetPrice()
        {
            return _order.GetPrice() + _price;
        }
    }
}
