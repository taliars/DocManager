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

        public ObjectDataViewModel ObjectDataViewModel { get; set; }

        public ProtocolViewModel ProtocolViewModel { get; set; }

        public ActViewModel ActsViewModel { get; set; }

        public DeviceViewModel DevicesViewModel { get; set; }

        public WeatherDayViewModel WeatherDaysViewModel { get; set; }

        public SettingsViewModel SettingsViewModel { get; set; }

        public RelayCommand Save => new RelayCommand(async o =>
        {
            bool delete = await confirm("Сохранить?", "бля");

            if (!delete)
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

        public MainViewModel(Func<string, string, Task<bool>> confirm)
        {
            this.confirm = confirm;

            _objectDataProvider = new JsonDataProvider("abc", "devices");
            var orderData = _objectDataProvider.OrderData;
            ObjectDataViewModel = new ObjectDataViewModel(orderData);
            ProtocolViewModel = new ProtocolViewModel(orderData);
            ActsViewModel = new ActViewModel(orderData);
            WeatherDaysViewModel = new WeatherDayViewModel(orderData.WeatherDays);
            DevicesViewModel = new DeviceViewModel(orderData.Devices);
        }
    }
}