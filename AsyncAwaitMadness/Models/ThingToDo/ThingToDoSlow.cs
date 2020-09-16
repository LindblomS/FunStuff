using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitMadness
{
    public class ThingToDoSlow : IThingToDo
    {
        public async Task DoThingAsync()
        {
            var awesomeFunc = new Func<int, int>((number) =>
            {
                return number++;
            });

            var result = 0;
            var randomNumber = new Random().Next(1, 100);

            for (int i = 0; i < randomNumber; i++)
            {
                result += await Task.Run(() => awesomeFunc(i));
                Thread.Sleep(new Random().Next(1, 1000));
            }
        }
    }
}
