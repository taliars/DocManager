using System.Collections.Generic;
using DocManager.Abstractions;
using DocManager.Core;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel.ViewModels
{
    public class OrderViewModel : PropertyChangedBase
    {
        public RelayCommand SaveOrder { get; }

        public RelayCommand AddOrder { get; }

        public RelayCommand GetOrder { get; }

        public List<OrderTuple> OrderNames { get; set; }


        public OrderViewModel(IOrderHelper orderHelper, Order currentOrder)
        {

            SaveOrder = new RelayCommand(async o =>
            {
                await orderHelper.SaveOrderAsync(currentOrder.Id, currentOrder);
            });

            AddOrder = new RelayCommand(async o =>
            {
                currentOrder = await orderHelper.CreateNewOrderAsync();
                OrderNames = orderHelper.GetOrderNames();
                NotifyPropertyChanged(nameof(OrderNames));
            });

            GetOrder = new RelayCommand(o => currentOrder = orderHelper.GetById(((OrderTuple)o)?.Id ?? currentOrder.Id));
        }
    }




}
