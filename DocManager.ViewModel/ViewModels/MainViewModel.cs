using DocManager.Core;
using DocManager.Data;
using DocManager.Data.Json;
using DocManager.ViewModel.Common;
using DocManager.ViewModel.Helpers;
using System;
using System.Threading.Tasks;

namespace DocManager.ViewModel
{
    public class MainViewModel : PropertyChangedBase
    {
        private IOrderData orderData;

        private readonly Func<string, string, bool, Task<bool>> actionAffirm;
        private readonly Func<string, string, Task<bool>> inputAffirm;
        private readonly Settings settings;
        private int orderId;

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
            bool ensure = await inputAffirm("Новый заказ", "Введите номер заказа");

            if (!ensure)
            {
                return;
            }

            await Task.Run(() => orderData.Add(order: new Order() { Id = 3, }));
        });

        public MainViewModel(
            Func<string, string, bool, Task<bool>> actionAffirm,
            Func<string, string, Task<bool>> inputAffirm,
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

            var id = 2;
            orderId = id;

            orderData = new JsonOrderData(settings.SourceFolderPath);
            var order = orderData.GetById(id);


            ObjectDataViewModel = new ObjectDataViewModel(order);
            ProtocolViewModel = new ProtocolViewModel(order, settings, move, actionAffirm);
            ActsViewModel = new ActViewModel(order);
            WeatherDaysViewModel = new WeatherDayViewModel(order.WeatherDays);
            DevicesViewModel = new DeviceViewModel(order.Devices);
        }
    }
}