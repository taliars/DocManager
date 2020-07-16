using DocManager.Core;
using DocManager.Data;
using DocManager.Data.Json;
using DocManager.ViewModel.Common;
using DocManager.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocManager.ViewModel
{
    public class MainViewModel : PropertyChangedBase
    {
        private readonly IOrderData orderData;

        private readonly Func<string, string, bool, Task<bool>> actionAffirm;
        private readonly Func<string, string, Task<string>> inputAffirm;
        private readonly Settings settings;
        private int orderId;

        public List<OrderTuple> OrderNames { get; set; }

        public ObjectDataViewModel ObjectDataViewModel { get; set; }

        public ProtocolViewModel ProtocolViewModel { get; set; }

        public ActViewModel ActsViewModel { get; set; }

        public DeviceViewModel DevicesViewModel { get; set; }

        public WeatherDayViewModel WeatherDaysViewModel { get; set; }

        public SettingsViewModel SettingsViewModel { get; set; }

        public RelayCommand Save => new RelayCommand(async o =>
        {
            bool ensure = await actionAffirm("Сохранить?", "Сохранить внесенные изменения", false);

            if (!ensure)
            {
                return;
            }

            await Task.Run(() => orderData.Update(this.ToOrder(this.orderId)));
        });

        public RelayCommand Add => new RelayCommand(async o =>
        {
            var ensure = await inputAffirm("Новый заказ", "Введите номер заказа");

            if (string.IsNullOrEmpty(ensure))
            {
                return;
            }

            var order = new Order
            {
                ObjectData = new ObjectData
                {
                    Order = ensure
                }
            };

            await Task.Run(() => orderData.Add(order));
            OrderNames = orderData.GetGetOrderNames();
            NotifyPropertyChanged(nameof(OrderNames));
        });

        public RelayCommand GetObjectName => new RelayCommand(o =>
        {
            var orderTuple = (OrderTuple)o;
            var order = orderData.GetById(orderTuple.Id);
            orderId = order.Id;
            ObjectDataViewModel = new ObjectDataViewModel(order);
            NotifyPropertyChanged(nameof(ObjectDataViewModel));
        });

        public MainViewModel(
            Func<string, string, bool, Task<bool>> actionAffirm,
            Func<string, string, Task<string>> inputAffirm,
            Func<string, string, string> move)
        {
            this.actionAffirm = actionAffirm;
            this.inputAffirm = inputAffirm;

            settings = new Settings
            {
                TemplatesPath = @"D:\trash\DocManager\норд\формы протоколов",
                SourceFolderPath = @"D:\trash\DocManager\норд\source",
                FinalPath = @"D:\trash\DocManager\норд\final",
            };

            var id = 1;
            orderId = id;

            orderData = new JsonOrderData(settings.SourceFolderPath);
            var order = orderData.GetById(id);

            OrderNames = orderData.GetGetOrderNames();


            ObjectDataViewModel = new ObjectDataViewModel(order);
            ProtocolViewModel = new ProtocolViewModel(order, settings, move, actionAffirm);
            ActsViewModel = new ActViewModel(order);
            WeatherDaysViewModel = new WeatherDayViewModel(order.WeatherDays);
            DevicesViewModel = new DeviceViewModel(order.Devices);
        }
    }
}