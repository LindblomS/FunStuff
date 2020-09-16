using System;
using System.Threading.Tasks;

namespace AsyncAwaitMadness
{
    public interface IDoThings
    {
        Task DoThingsAsync();
        int ThingsToDo { get; }
        int ThingsDone { get; }
        Action ThingDoneCallback { get; set; }
    }
}
