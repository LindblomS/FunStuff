using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitMadness.Models.Observer
{
    public class Unsubscriber : IDisposable
    {
        private readonly IList<IObserver<IThingToDo>> _observers;
        private readonly IObserver<IThingToDo> _observer;

        public Unsubscriber(IList<IObserver<IThingToDo>> observers, IObserver<IThingToDo> observer)
        {
            _observers = observers ?? throw new ArgumentNullException(nameof(observers));
            _observer = observer ?? throw new ArgumentNullException(nameof(observer));
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
