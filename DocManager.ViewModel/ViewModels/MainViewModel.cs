using DocManager.Data.DataProviders;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel
{
    public class MainViewModel 
    {
        private IOrderDataProvider _objectDataProvider;

        public ObjectDataViewModel ObjectDataViewModel { get; set; }

        public ProtocolViewModel ProtocolViewModel { get; set; }

        public ActViewModel ActsViewModel { get; set; }

        public DeviceViewModel DevicesViewModel { get; set; }

        public WeatherDayViewModel WeatherDaysViewModel { get; set; }

        public SettingsViewModel SettingsViewModel { get; set; }

        public void Save()
        {
            _objectDataProvider.Save();
        }

        public MainViewModel()
        {
            _objectDataProvider = new JsonDataProvider("abc");
            var orderData = _objectDataProvider.OrderData;

            ObjectDataViewModel = new ObjectDataViewModel(orderData.ObjectData);
            ProtocolViewModel = new ProtocolViewModel(orderData.Protocols);
            ActsViewModel = new ActViewModel(orderData.Acts);
            WeatherDaysViewModel = new WeatherDayViewModel(orderData.WeatherDays);
            DevicesViewModel = new DeviceViewModel(orderData.Devices);

            ObjectDataViewModel.Order = "123";
            ObjectDataViewModel.CustomerAddress = "asdasd";
        }
    }
}