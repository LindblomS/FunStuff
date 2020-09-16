using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitMadness
{
    public class DoThingsCollectionViewModel : BaseViewModel
    {
        private readonly ObservableCollection<DoThingsViewModel> _doThingsViewModels;
        private readonly int _totalNumberOfThingsToDo;

        public DoThingsCollectionViewModel(ObservableCollection<DoThingsViewModel> doThingsViewModels)
        {
            _doThingsViewModels = doThingsViewModels ?? throw new ArgumentNullException(nameof(doThingsViewModels));
            _totalNumberOfThingsToDo = _doThingsViewModels.Select(vm => vm.DoThings.ThingsToDo).Aggregate((sum, val) => sum += val);
        }

        public int TotalNumberOfThingsToDo => _totalNumberOfThingsToDo;
        public ObservableCollection<DoThingsViewModel> DoThings => _doThingsViewModels;

    }
}
