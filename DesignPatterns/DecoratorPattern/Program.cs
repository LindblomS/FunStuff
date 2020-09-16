using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var steakWithFries = new Fries(new Steak());
            Console.WriteLine($"{steakWithFries.GetDescription()}, price: {steakWithFries.GetPrice()}");
        }
    }
}
