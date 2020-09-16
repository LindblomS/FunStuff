using System;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var sub = new Subject();
            var observerA = new Observer("Observer Dave");
            var observerB = new Observer("Observer Lisa");
            sub.Subscribe(observerA);
            sub.Subscribe(observerB);

            for (int i = 0; i < 10; i++)
            {
                sub.SendMessage($"Message nr. {i}");
            }

            sub.NothingMoreToWrite();
        }
    }
}
