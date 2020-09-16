using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAwaitMadness
{
    public class DoThingsSameTime : IDoThings
    {
        private readonly IEnumerable<IThingToDo> _thingsToDo;
        private int _thingsDone;

        public DoThingsSameTime(IEnumerable<IThingToDo> thingsToDo)
        {
            _thingsToDo = thingsToDo ?? throw new ArgumentNullException(nameof(thingsToDo));
        }

        public int ThingsToDo => _thingsToDo.Count();
        public int ThingsDone => _thingsDone;
        public Action ThingDoneCallback { get; set; }

        public async Task DoThingsAsync()
        {
            _thingsDone = 0;
            var tasks = new List<Task>();

            foreach (var thingToDo in _thingsToDo)
            {
                tasks.Add(thingToDo.DoThingAsync());
            }

            var runningTasks = tasks.Select(AwaitAndProcessAsync).ToList();
            await Task.WhenAll(runningTasks);
        }

        private async Task AwaitAndProcessAsync(Task task)
        {
            await task;
            _thingsDone += 1;
            ThingDoneCallback?.Invoke();
        }
    }
}
