using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Unsubscriber : IDisposable
    {
        private IList<IObserver<string>> _observers;
        private IObserver<string> _observer;

        public Unsubscriber(IList<IObserver<string>> observers, IObserver<string> observer)
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
