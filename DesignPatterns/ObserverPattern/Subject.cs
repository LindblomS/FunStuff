using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Subject : IObservable<string>
    {
        private IList<IObserver<string>> _observers;

        public Subject()
        {
            _observers = new List<IObserver<string>>();
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber(_observers, observer);
        }

        public void SendMessage(string message)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(message);
            }
        }

        public void NothingMoreToWrite()
        {
            foreach (var observer in _observers)
                observer.OnCompleted();

            _observers.Clear();
        }
    }
}
