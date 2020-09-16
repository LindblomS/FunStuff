using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public abstract class Condiment : IFood
    {
        private readonly IFood _food;
        protected string _name;
        protected int _price;

        public Condiment(IFood food)
        {
            _food = food;
        }
        public string GetDescription()
        {
            return $"{_food.GetDescription()}, {_name}";
        }

        public int GetPrice()
        {
            return _food.GetPrice() + _price;
        }
    }
}
