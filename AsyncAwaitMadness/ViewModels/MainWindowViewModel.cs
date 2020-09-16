using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AsyncAwaitMadness.Extensions;

namespace AsyncAwaitMadness
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<DoThingsCollectionViewModel> _thingsGettingDone;
        public MainWindowViewModel()
        {
            DoThingsCommand = new RelayCommand(execute => Task.Run(() => DoThings()));
            _thingsGettingDone = GetThingsThatNeedToBeDone();
        }

        public ObservableCollection<DoThingsCollectionViewModel> ThingsGettingDone => _thingsGettingDone;

        public ICommand DoThingsCommand { get; set; }

        private ObservableCollection<DoThingsCollectionViewModel> GetThingsThatNeedToBeDone()
        {
            var collectionOfThingsThatNeedToBeDone = new ObservableCollection<DoThingsCollectionViewModel>();

            var thingsThatNeedToBeDone = new ObservableCollection<DoThingsViewModel>();

            for (int i = 0; i < 10; i++)
            {
                thingsThatNeedToBeDone.Add(new DoThingsViewModel(new DoThingsSameTime(GetThingsToDo())));
            }

            collectionOfThingsThatNeedToBeDone.Add(new DoThingsCollectionViewModel(thingsThatNeedToBeDone));

            thingsThatNeedToBeDone = new ObservableCollection<DoThingsViewModel>();

            for (int i = 0; i < 10; i++)
            {
                thingsThatNeedToBeDone.Add(new DoThingsViewModel(new DoThingsInQueue(GetThingsToDo())));
            }

            collectionOfThingsThatNeedToBeDone.Add(new DoThingsCollectionViewModel(thingsThatNeedToBeDone));

            return collectionOfThingsThatNeedToBeDone;
        }

        private IList<IThingToDo> GetThingsToDo()
        {
            var thingsToDo = new List<IThingToDo>();

            for (int ii = 0; ii < 100; ii++)
            {
                thingsToDo.Add(new ThingToDo());
            }

            for (int ii = 0; ii < 100; ii++)
            {
                thingsToDo.Add(new ThingToDoSlow());
            }

            for (int iii = 0; iii < 1000; iii++)
            {
                thingsToDo.Add(new ThingToDoFast());
            }

            thingsToDo.Shuffle();
            return thingsToDo;
        }

        private async Task DoThings()
        {
            var tasks = new List<Task>();

            foreach (var thingsToGetDone in _thingsGettingDone.SelectMany(vm => vm.DoThings.Select(x => x.DoThings)))
            {
                tasks.Add(thingsToGetDone.DoThingsAsync());
            }

            await Task.WhenAll(tasks);
        }
    }
}
