namespace Restaurant
{
    public class Fish : IOrderItem
    {
        public string Name => "Fish";
        public string GetDescription()
        {
            return Name;
        }

        public int SecondsToMake()
        {
            return 10;
        }

        public int GetPrice()
        {
            return 80;
        }
    }
}
