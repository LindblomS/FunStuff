using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Restaurant.Models
{
    public interface IOkOrCancel<T> : IRequireViewIdentification
    {
        public bool IsCanceled { get; }
        public T ReturnObject { get; }
        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}
