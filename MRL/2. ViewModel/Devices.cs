using System;
using System.ComponentModel;
using MRL.Model;

namespace MRL.ViewModel
{
    public class DeviceViewModel: PropertyChangedClass
    {
        private readonly Device _device;

        public Device Device
        {
            get => _device;
        }

        public bool IsSelected
        {
            get => Device.IsSelected; 
            set { Device.IsSelected = value; NotifyPropertyChanged("IsSelected");}
                
        }

        public string Name
        {
            get => Device.Name;
            set { Device.Name = value; NotifyPropertyChanged("Name"); }

        }

        public string Use
        {
            get => Device.Use;
            set { Device.Use = value; NotifyPropertyChanged("Use"); }

        }

        public string Number
        {
            get => Device.Number;
            set { Device.Number = value; NotifyPropertyChanged("Number"); }

        }

        public string VerNumber
        {
            get => Device.VerNumber;
            set { Device.VerNumber = value; NotifyPropertyChanged("VerNumber"); }

        }

        public string VerOrganization
        {
            get => Device.VerOrganization;
            set { Device.VerOrganization = value; NotifyPropertyChanged("VerOrganization"); }

        }

        public DateTime VerExpiration
        {
            get => Device.VerExpiration;
            set { Device.VerExpiration = value; NotifyPropertyChanged("VerExpiration"); }

        }

        public string Range
        {
            get => Device.Range;
            set { Device.Range = value; NotifyPropertyChanged("Range"); }

        }

        public string Fault
        {
            get => Device.Fault;
            set { Device.Fault = value; NotifyPropertyChanged("Fault"); }

        }

        public DeviceViewModel(Device device)
        {
            _device = device;
        }
    }
}
