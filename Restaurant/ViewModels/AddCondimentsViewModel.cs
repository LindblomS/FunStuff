using Restaurant.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Restaurant.ViewModels
{
    public class AddCondimentsViewModel : BaseViewModel, IRequireViewIdentification
    {
        private ObservableCollection<CondimentViewModel> _condiments;
        private readonly Guid _viewId;

        public AddCondimentsViewModel()
        {
            _condiments = GetCondiments();
            _viewId = Guid.NewGuid();
            OkCommand = new RelayCommand(execute => Ok());
            CancelCommand = new RelayCommand(execute => Cancel());
        }

        public Guid ViewId => _viewId;
        public bool IsCanceled { get; private set; }
        public ObservableCollection<CondimentViewModel> Condiments => _condiments;
        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        private void Ok()
        {
            IsCanceled = false;
            WindowManager.CloseWindow(_viewId);
        }

        private void Cancel()
        {
            IsCanceled = true;
            _condiments.Clear();
            WindowManager.CloseWindow(_viewId);
        }

        private ObservableCollection<CondimentViewModel> GetCondiments()
        {
            return new ObservableCollection<CondimentViewModel>
            {
                new CondimentViewModel { Name = "Fries" },
                new CondimentViewModel { Name = "Rice" }
            };
        }

    }
}
