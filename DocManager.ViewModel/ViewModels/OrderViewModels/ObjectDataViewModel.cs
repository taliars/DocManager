using System;
using DocManager.Core;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel
{
    public class ObjectDataViewModel: PropertyChangedBase
    {
        private ObjectData objectData;

        public string ObjectName
        {
            get => objectData?.ObjectName;
            set
            {
                objectData.ObjectName = value;
                NotifyPropertyChanged(nameof(ObjectName));
            }
        }

        public string ObjectAddress
        {
            get => objectData?.ObjectAddress;
            set
            {
                objectData.ObjectAddress = value;
                NotifyPropertyChanged(nameof(ObjectAddress));
            }
        }

        public string Measurement
        {
            get => objectData?.Measurement;
            set
            {
                objectData.Measurement = value;
                NotifyPropertyChanged(nameof(Measurement));
            }
        }

        public string Purpose
        {
            get => objectData?.Purpose;
            set
            {
                objectData.Purpose = value;
                NotifyPropertyChanged(nameof(Purpose));
            }
        }

        public string CustomerName
        {
            get => objectData?.CustomerName;
            set
            {
                objectData.CustomerName = value;
                NotifyPropertyChanged(nameof(CustomerName));
            }
        }

        public string CustomerAddress
        {
            get => objectData?.CustomerAddress;
            set
            {
                objectData.CustomerAddress = value;
                NotifyPropertyChanged(nameof(CustomerAddress));
            }
        }

        public string Order
        {
            get => objectData?.Order;
            set
            {
                objectData.Order = value;
                NotifyPropertyChanged(nameof(Order));
                NotifyPropertyChanged(nameof(ObjectDataViewModel));
            }
        }

        public string Comment
        {
            get => objectData?.Comment;
            set
            {
                objectData.Comment = value;
                NotifyPropertyChanged(nameof(Comment));
            }
        }

        public ObjectDataViewModel(OrderData orderData)
        {
            objectData = orderData.ObjectData;
        }
    }
}
