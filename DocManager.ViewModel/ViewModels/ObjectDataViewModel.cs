using DocManager.Data.DataProviders;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel
{
    public class ObjectDataViewModel : PropertyChangedBase
    {
        private InnerObjectDataViewModel InnerData { get; }

        private IObjectDataProvider _objectDataProvider;

        public string ObjectName
        {
            get => InnerData.ObjectName;
            set
            {
                InnerData.ObjectName = value;
                NotifyPropertyChanged(nameof(ObjectName));
            }
        }

        public string ObjectAddress
        {
            get => InnerData.ObjectAddress;
            set
            {
                InnerData.ObjectAddress = value;
                NotifyPropertyChanged(nameof(ObjectAddress));
            }
        }

        public string Measurement
        {
            get => InnerData.Measurement;
            set
            {
                InnerData.Measurement = value;
                NotifyPropertyChanged(nameof(Measurement));
            }
        }

        public string Purpose
        {
            get => InnerData.Purpose;
            set
            {
                InnerData.Purpose = value;
                NotifyPropertyChanged(nameof(Purpose));
            }
        }

        public string CustomerName
        {
            get => InnerData.CustomerName;
            set
            {
                InnerData.CustomerName = value;
                NotifyPropertyChanged(nameof(CustomerName));
            }
        }

        public string CustomerAddress
        {
            get => InnerData.CustomerAddress;
            set
            {
                InnerData.CustomerAddress = value;
                NotifyPropertyChanged(nameof(CustomerAddress));
            }
        }

        public string Order
        {
            get => InnerData.Order;
            set
            {
                InnerData.Order = value;
                NotifyPropertyChanged(nameof(Order));
            }
        }

        public string Comment
        {
            get => InnerData.Comment;
            set
            {
                InnerData.Comment = value;
                NotifyPropertyChanged(nameof(Comment));
            }
        }

        public ProtocolViewModel Protocols { get; set; }

        public ActViewModel Acts { get; set; }

        public DeviceViewModel Devices { get; set; }

        public WeatherDayViewModel WeatherDays { get; set; }

        public ObjectDataViewModel(IObjectDataProvider objectDataProvider)
        {
            _objectDataProvider = objectDataProvider;
            InnerData = objectDataProvider.ObjectData.ToInnerObjectDataViewModel();

            Protocols = new ProtocolViewModel(InnerData.Protocols);
            Acts = new ActViewModel(InnerData.Acts);
            WeatherDays = new WeatherDayViewModel(InnerData.WeatherDays);
            Devices = new DeviceViewModel(InnerData.Devices);
        }
    }
}