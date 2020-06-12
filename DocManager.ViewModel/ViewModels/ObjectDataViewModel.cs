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

        public Protocol SelectedProtocol
        {
            get => selectedProtocol;
            set
            {
                selectedProtocol = value;
                NotifyPropertyChanged(nameof(SelectedProtocol));
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

        public RelayCommand CommandAddDate => new RelayCommand(o =>
        {
            InnerData.WeatherDays.Add(new WeatherDay());
            NotifyPropertyChanged(nameof(WeatherDays));
        });

        public RelayCommand CommandAddAct => new RelayCommand(o =>
        {
            InnerData.Acts.Add(new Act());
            NotifyPropertyChanged(nameof(Acts));
        });

        public RelayCommand CommandAddProtocol => new RelayCommand(o =>
        {
            if (!(o is string s))
            {
                return;
            }

            InnerData.Protocols.Add(new Protocol
            {
                Species = s,
                Path = "not specified",
                Date = DateTime.Now,
                Dates = null,
                Name = Protocol.GetNameForProtocol(s, Order),
                Perfomer = "Астахов П.Ю.",
            });
            NotifyPropertyChanged(nameof(Protocols));
        });


        public RelayCommand RemoveProtocol => new RelayCommand(o =>
        {
            if (!(o is Protocol p))
            {
                return;
            }

            InnerData.Protocols.Remove(p);
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