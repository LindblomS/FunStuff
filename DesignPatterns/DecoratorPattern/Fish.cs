using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class Fish : IFood
    {
        public string GetDescription()
        {
            return "Fish";
        }

        public int GetPrice()
        {
            return 70;
        }
    }
}
