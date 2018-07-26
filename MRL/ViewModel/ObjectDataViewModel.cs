using System;
using System.ComponentModel;
using System.Collections.Generic;

using MRL.Model;

namespace MRL.ViewModel
{
    public class ObjectDataViewModel: PropertyChangedClass
    {
        public ObjectData ObjectData { get; }

        #region properties

        public string ObjectName
        {
            get => ObjectData.ObjectName;
            set { ObjectData.ObjectName = value; NotifyPropertyChanged("ObjectName"); }
        }

        public string ObjectAddress
        {
            get => ObjectData.ObjectAddress;
            set { ObjectData.ObjectAddress = value; NotifyPropertyChanged("ObjectAddress"); }            
        }

        public string Measurement
        {
            get => ObjectData.Measurement;            
            set { ObjectData.Measurement = value; NotifyPropertyChanged("Measurement"); }
        }

        public string Purpose
        {
            get => ObjectData.Purpose;
            set { ObjectData.Purpose = value; NotifyPropertyChanged("Purpose"); }
        }

        public string CustomerName
        {
            get => ObjectData.CustomerName;           
            set { ObjectData.CustomerName = value; NotifyPropertyChanged("CustomerName"); }
        }

        public string CustomerAddress
        {
            get => ObjectData.CustomerAddress;
            set { ObjectData.CustomerAddress = value; NotifyPropertyChanged("CustomerAddress"); }
        }

        public string Order
        {
            get => ObjectData.Order;
            set { ObjectData.Order = value; NotifyPropertyChanged("Order"); }
        }

        public List<Act> Acts
        {
            get => ObjectData.Acts;
            set { ObjectData.Acts = value; NotifyPropertyChanged("Acts"); }
        }

        public List<Protocol> Protocols
        {
            get => ObjectData.Protocols;
            set { ObjectData.Protocols = value; NotifyPropertyChanged("Protocols"); }
        }
        
        #endregion

        public ObjectDataViewModel(ObjectData objectData)
        {
            this.ObjectData = objectData;
        }  
    }

    public class PropertyChangedClass
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
