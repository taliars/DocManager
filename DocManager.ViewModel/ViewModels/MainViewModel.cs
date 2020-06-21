using DocManager.Data.DataProviders;
using DocManager.ViewModel.Common;
using System;
using System.Threading.Tasks;

namespace DocManager.ViewModel
{
    public class MainViewModel : PropertyChangedBase
    {
        private IOrderDataProvider _objectDataProvider;
        private string statusMessage;
        private readonly Func<string, string, Task<bool>> confirm;
        private readonly Func<string, string, Task<bool>> affirm;

        public ObjectDataViewModel ObjectDataViewModel { get; set; }

        public ProtocolViewModel ProtocolViewModel { get; set; }

        public ActViewModel ActsViewModel { get; set; }

        public DeviceViewModel DevicesViewModel { get; set; }

        public WeatherDayViewModel WeatherDaysViewModel { get; set; }

        public SettingsViewModel SettingsViewModel { get; set; }

        public RelayCommand Save => new RelayCommand(async o =>
        {
            bool ensure = await confirm("Сохранить?", "Сохранить внесенные изменения");

            if (!ensure)
            {
                return;
            }

            await Task.Run(() => _objectDataProvider.Save());
            StatusMessage = "Saved";
        });

        public string StatusMessage
        {
            get => statusMessage;
            set
            {
                statusMessage = value;
                NotifyPropertyChanged(nameof(StatusMessage));
            }
        }

        public MainViewModel(
            Func<string, string, Task<bool>> confirm,
            Func<string, string, Task<bool>> affirm,
            Func<string, string, string> move)
        {
            this.confirm = confirm;
            this.affirm = affirm;

            _objectDataProvider = new JsonDataProvider("abc", "devices");
            var orderData = _objectDataProvider.OrderData;
            ObjectDataViewModel = new ObjectDataViewModel(orderData);
            ProtocolViewModel = new ProtocolViewModel(orderData, move, affirm);
            ActsViewModel = new ActViewModel(orderData);
            WeatherDaysViewModel = new WeatherDayViewModel(orderData.WeatherDays);
            DevicesViewModel = new DeviceViewModel(orderData.Devices);
        }
    }
}