using System;
using DocManager.Core;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel
{
    public class ObjectDataViewModel : PropertyChangedBase
    {
        internal ObjectData ObjectData;

        public string ObjectName
        {
            get => ObjectData?.ObjectName;
            set
            {
                ObjectData.ObjectName = value;
                NotifyPropertyChanged(nameof(ObjectName));
            }
        }

        public string ObjectAddress
        {
            get => ObjectData?.ObjectAddress;
            set
            {
                ObjectData.ObjectAddress = value;
                NotifyPropertyChanged(nameof(ObjectAddress));
            }
        }

        public string Measurement
        {
            get => ObjectData?.Measurement;
            set
            {
                ObjectData.Measurement = value;
                NotifyPropertyChanged(nameof(Measurement));
            }
        }

        public string Purpose
        {
            get => ObjectData?.Purpose;
            set
            {
                ObjectData.Purpose = value;
                NotifyPropertyChanged(nameof(Purpose));
            }
        }

        public string CustomerName
        {
            get => ObjectData?.CustomerName;
            set
            {
                ObjectData.CustomerName = value;
                NotifyPropertyChanged(nameof(CustomerName));
            }
        }

        public string CustomerAddress
        {
            get => ObjectData?.CustomerAddress;
            set
            {
                ObjectData.CustomerAddress = value;
                NotifyPropertyChanged(nameof(CustomerAddress));
            }
        }

        public string Order
        {
            get => ObjectData?.Order;
            set
            {
                ObjectData.Order = value;
                NotifyPropertyChanged(nameof(Order));
                NotifyPropertyChanged(nameof(ObjectDataViewModel));
            }
        }

        public string Comment
        {
            get => ObjectData?.Comment;
            set
            {
                ObjectData.Comment = value;
                NotifyPropertyChanged(nameof(Comment));
            }
        }

        public string Inn
        {
            get => ObjectData?.Inn;
            set
            {
                ObjectData.Inn = value;
                NotifyPropertyChanged(nameof(Inn));
            }
        }

        public string Ogrn
        {
            get => ObjectData?.Ogrn;
            set
            {
                ObjectData.Ogrn = value;
                NotifyPropertyChanged(nameof(Ogrn));
            }
        }

        public ObjectDataViewModel(Order order)
        {
            this.ObjectData = order.ObjectData;
        }
    }
}
