using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class Sauce : Condiment
    {
        public Sauce(IFood food) 
            : base(food)
        {
            _name = "Sauce";
            _price = 2;
        }
    }
}
