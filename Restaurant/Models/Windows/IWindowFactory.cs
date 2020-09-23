using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public interface IWindowFactory
    {
        WindowWithViewModel GetAddCondimentsWindow();
        WindowWithViewModel GetCreateOrderWindow();
        WindowWithViewModel GetMainWindow();
    }
}
