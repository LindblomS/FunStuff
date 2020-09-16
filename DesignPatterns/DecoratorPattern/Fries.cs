using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class Fries : Condiment
    {
        public Fries(IFood food)
            : base(food)
        {
            _name = "Fries";
            _price = 5;
        }
    }
}
