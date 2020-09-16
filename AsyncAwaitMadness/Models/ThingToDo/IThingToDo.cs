using System.Threading.Tasks;

namespace AsyncAwaitMadness
{
    public interface IThingToDo
    {
        Task DoThingAsync();
    }
}
