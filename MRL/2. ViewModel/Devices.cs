using System;
using System.ComponentModel;
using MRL.Model;

namespace MRL.ViewModel
{
    class Devices: Device
        {
        public bool IsSelected
        {
            get { return _isselected; }
            set
            {
                if (_isselected != value)
                {
                    _isselected = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("IsSelected"));
                }
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Name"));
                }
            }
        }
        public string Use
        {
            get { return _use; }
            set
            {
                if (_use != value)
                {
                    _use = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Use"));
                }
            }
        }
        public string Number
        {
            get { return _number; }
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Number"));
                }
            }
        }
        public string VerNumber
        {
            get { return _vernumber; }
            set
            {
                if (_vernumber != value)
                {
                    _vernumber = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("VerNumber"));
                }
            }
        }
        public string VerOrganization
        {
            get { return _verorganization; }
            set
            {
                if (_verorganization != value)
                {
                    _verorganization = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("VerOrganization"));
                }
            }
        }
        public DateTime VerExpiration
        {
            get { return _verexpiration; }
            set
            {
                if (_verexpiration != value)
                {
                    _verexpiration = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("VerExpiration"));
                }
            }
        }
        public string Range
        {
            get { return _range; }
            set
            {
                if (_range != value)
                {
                    _range = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Range"));
                }
            }
        }
        public string Fault
        {
            get { return _fault; }
            set
            {
                if (_fault != value)
                {
                    _fault = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Fault"));
                }
            }
        }
    }
}
