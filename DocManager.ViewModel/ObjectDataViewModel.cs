using System.Collections.Generic;
using System.Linq;
using DocManager.Core;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel
{
    public class ObjectDataViewModel : PropertyChangedClass
    {
        private ObjectInfo ObjectData { get; }

        public string ObjectName
        {
            get => ObjectData.ObjectName;
            set
            {
                ObjectData.ObjectName = value;
                NotifyPropertyChanged(nameof(ObjectName));
            }
        }

        public string ObjectAddress
        {
            get => ObjectData.ObjectAddress;
            set
            {
                ObjectData.ObjectAddress = value;
                NotifyPropertyChanged(nameof(ObjectAddress));
            }
        }

        public string Measurement
        {
            get => ObjectData.Measurement;
            set
            {
                ObjectData.Measurement = value;
                NotifyPropertyChanged(nameof(Measurement));
            }
        }

        public string Purpose
        {
            get => ObjectData.Purpose;
            set
            {
                ObjectData.Purpose = value;
                NotifyPropertyChanged(nameof(Purpose));
            }
        }

        public string CustomerName
        {
            get => ObjectData.CustomerName;
            set
            {
                ObjectData.CustomerName = value;
                NotifyPropertyChanged(nameof(CustomerName));
            }
        }

        public string CustomerAddress
        {
            get => ObjectData.CustomerAddress;
            set
            {
                ObjectData.CustomerAddress = value;
                NotifyPropertyChanged(nameof(CustomerAddress));
            }
        }

        public string Order
        {
            get => ObjectData.Order;
            set
            {
                ObjectData.Order = value;
                NotifyPropertyChanged(nameof(Order));
            }
        }

        public List<Act> Acts
        {
            get => ObjectData.Acts?.ToList();
            set
            {
                ObjectData.Acts = value;
                NotifyPropertyChanged(nameof(Acts));
            }
        }

        public List<Protocol> Protocols
        {
            get => ObjectData.Protocols?.ToList();
            set
            {
                ObjectData.Protocols = value;
                NotifyPropertyChanged(nameof(Protocols));
            }
        }

        public ObjectDataViewModel(ObjectInfo objectData)
        {
            ObjectData = objectData;
        }
    }
}