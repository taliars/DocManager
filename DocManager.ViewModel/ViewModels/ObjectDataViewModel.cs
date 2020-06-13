using DocManager.Core;
using DocManager.Data.DataProviders;
using DocManager.ViewModel.Common;
using System;
using System.Collections.ObjectModel;

namespace DocManager.ViewModel
{
    public class ObjectDataViewModel : PropertyChangedBase
    {
        private Protocol selectedProtocol;

        private WeatherDay selectedWeatherDay;

        private Act selectedAct;

        public Protocol SelectedProtocol
        {
            get => selectedProtocol;
            set
            {
                selectedProtocol = value;
                NotifyPropertyChanged(nameof(SelectedProtocol));
            }
        }

        public Act SelectedAct
        {
            get => selectedAct;
            set
            {
                selectedAct = value;
                NotifyPropertyChanged(nameof(SelectedAct));
            }
        }

        public WeatherDay SelectedWeatherDay
        {
            get => selectedWeatherDay;
            set
            {
                selectedWeatherDay = value;
                NotifyPropertyChanged(nameof(SelectedWeatherDay));
            }
        }

    

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

        public string Comment
        {
            get => InnerData.Comment;
            set
            {
                InnerData.Comment = value;
                NotifyPropertyChanged(nameof(Comment));
            }
        }


        public RelayCommand AddDate => new RelayCommand(o =>
        {
            InnerData.WeatherDays.Add(new WeatherDay());
            NotifyPropertyChanged(nameof(WeatherDays));
        });

        public RelayCommand RemoveDate => new RelayCommand(o =>
        {
            InnerData.WeatherDays.Remove(SelectedWeatherDay);
            NotifyPropertyChanged(nameof(WeatherDays));
        });

        public RelayCommand AddAct => new RelayCommand(o =>
        {
            if (!(o is string species))
            {
                return;
            }

            InnerData.Acts.Add(new Act().New(species, DateTime.Now, Order));
            NotifyPropertyChanged(nameof(Acts));
        });

        public RelayCommand RemoveAct => new RelayCommand(o =>
        {
            if (!(o is Act act))
            {
                return;
            }

            InnerData.Acts.Remove(act);
            NotifyPropertyChanged(nameof(Acts));
        });

        public RelayCommand AddProtocol => new RelayCommand(o =>
        {
            if (!(o is string species))
            {
                return;
            }

            InnerData.Protocols.Add((new Protocol()).New(species, DateTime.Now, Order));
            NotifyPropertyChanged(nameof(Protocols));
        });

        public RelayCommand RemoveProtocol => new RelayCommand(o =>
        {
            if (!(o is Protocol protocol))
            {
                return;
            }

            InnerData.Protocols.Remove(protocol);
            NotifyPropertyChanged(nameof(Protocols));
        });

        public void Save()
        {
            _objectDataProvider.Save(InnerData.ToObjectData());
        }

        public ObjectDataViewModel(IObjectDataProvider objectDataProvider)
        {
            _objectDataProvider = objectDataProvider;
            InnerData = objectDataProvider.ObjectData.ToInnerObjectDataViewModel();
        }
    }
}