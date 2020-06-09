using DocManager.Core;
using DocManager.ViewModel.Common;
using System.Collections.ObjectModel;

namespace DocManager.ViewModel
{
    public class ObjectDataViewModel: PropertyChangedClass
    {
        private InnerObjectDataViewModel InnerData { get; }

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

        public ObservableCollection<Act> Acts
        {
            get => InnerData.Acts;
            set
            {
                InnerData.Acts = value;
                NotifyPropertyChanged(nameof(Acts));
            }
        }

        public ObservableCollection<Protocol> Protocols
        {
            get => InnerData.Protocols;
            set
            {
                InnerData.Protocols = value;
                NotifyPropertyChanged(nameof(Protocols));
            }
        }

        public ObservableCollection<WeatherDay> WeatherDays
        {
            get => InnerData.WeatherDays;
            set
            {
                InnerData.WeatherDays = value;
                NotifyPropertyChanged(nameof(WeatherDays));
            }
        }

        public RelayCommand CommandAddDate => new RelayCommand(o =>
        {
            InnerData.WeatherDays.Add(new WeatherDay());
            NotifyPropertyChanged(nameof(WeatherDays));
        });

        public ObjectDataViewModel(IObjectDataProvider objectDataProvider)
        {
            InnerData = objectDataProvider.GetObjectData;
        }
    }
}