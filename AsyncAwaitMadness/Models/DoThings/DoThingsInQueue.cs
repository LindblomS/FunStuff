using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAwaitMadness
{
    public class DoThingsInQueue : IDoThings
    {
        private readonly IEnumerable<IThingToDo> _thingsToDo;
        private int _thingsDone;

        public DoThingsInQueue(IEnumerable<IThingToDo> thingsToDo)
        {
            _thingsToDo = thingsToDo ?? throw new ArgumentNullException(nameof(thingsToDo));
        }

        public int ThingsToDo => _thingsToDo.Count();
        public int ThingsDone => _thingsDone;
        public Action ThingDoneCallback { get; set; }

        public async Task DoThingsAsync()
        {
            _thingsDone = 0;
            foreach (var thingToDo in _thingsToDo)
            {
                await thingToDo.DoThingAsync();
                _thingsDone += 1;
                ThingDoneCallback?.Invoke();
            }
        }
    }
}
