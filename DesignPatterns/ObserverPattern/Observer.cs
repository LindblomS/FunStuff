using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Observer : IObserver<string>
    {
        private readonly string _name;
        private IDisposable _unsubscriber;
        public Observer(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) _name = name ?? throw new ArgumentNullException("name cannot be null or empty");
            _name = name;
        }

        public string Name { get; }

        public void OnCompleted()
        {
            Console.WriteLine($"Nothing more to write: {_name}");
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            Console.WriteLine($"{value}: {_name}");
        }

        public void Register(Subject subject)
        {
            _unsubscriber = subject.Subscribe(this);
        }

        public void Unsubscribe(Subject subject)
        {
            _unsubscriber?.Dispose();
        }
    }
}
