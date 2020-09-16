using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitMadness
{
    public class ThingToDoFast : IThingToDo
    {
        public async Task DoThingAsync()
        {
            await Task.CompletedTask;
        }
    }
}
