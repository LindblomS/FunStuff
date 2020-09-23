using Restaurant.Models;
using Restaurant.Order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

namespace Restaurant.ViewModels
{
    public class AddCondimentsViewModel : BaseViewModel, IOkOrCancel<IEnumerable<CondimentViewModel>>
    {
        private ObservableCollection<CondimentViewModel> _condiments;
        private readonly Guid _viewId;
        private readonly IOrderRepository _orderRepository;

        public AddCondimentsViewModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _condiments = GetCondiments();
            _viewId = Guid.NewGuid();
            OkCommand = new RelayCommand(execute => Ok());
            CancelCommand = new RelayCommand(execute => Cancel());
        }

        public Guid ViewId => _viewId;
        public bool IsCanceled { get; private set; }
        public ObservableCollection<CondimentViewModel> Condiments => _condiments;
        public IEnumerable<CondimentViewModel> ReturnObject => _condiments.AsEnumerable();
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
            var condiemnts = new ObservableCollection<CondimentViewModel>();

            foreach (var item in _orderRepository.GetCondiments())
            {
                condiemnts.Add(new CondimentViewModel { Name = item });
            }

            return condiemnts;
        }

    }
}
