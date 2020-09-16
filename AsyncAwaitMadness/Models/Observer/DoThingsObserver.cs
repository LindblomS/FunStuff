using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitMadness.Models.Observer
{
    public class DoThingsObserver : IObserver<IThingToDo>
    {


        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(IThingToDo value)
        {
            throw new NotImplementedException();
        }
    }
}
