using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitMadness.Models.Observer
{
    public class ThingToDoObservable : IObservable<IThingToDo>
    {
        public IDisposable Subscribe(IObserver<IThingToDo> observer)
        {
            throw new NotImplementedException();
        }
    }
}
