using System;

namespace AsyncAwaitMadness
{
    public class DoThingsViewModel : BaseViewModel
    {
        private readonly IDoThings _doThings;

        public DoThingsViewModel(IDoThings doThings)
        {
            _doThings = doThings ?? throw new ArgumentNullException(nameof(doThings));
            _doThings.ThingDoneCallback = () => NotifyPropertyChanged(nameof(DoThings));
        }

        public IDoThings DoThings => _doThings;
    }
}
