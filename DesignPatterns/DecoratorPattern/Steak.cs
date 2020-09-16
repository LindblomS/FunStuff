using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class Steak : IFood
    {
        public string GetDescription()
        {
            return "Steak";
        }

        public int GetPrice()
        {
            return 100;
        }
    }
}
