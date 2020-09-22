namespace Restaurant
{
    public class Steak : IOrderItem
    {
        public string Name => "Steak";
        public string GetDescription()
        {
            return Name;
        }

        public int SecondsToMake()
        {
            return 20;
        }

        public int GetPrice()
        {
            return 100;
        }
    }
}
