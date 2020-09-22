namespace Restaurant
{
    public interface IOrderItem
    {
        public string Name { get; }
        string GetDescription();
        int SecondsToMake();
        int GetPrice();
    }
}
