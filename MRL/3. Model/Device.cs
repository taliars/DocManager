using System;
using System.ComponentModel;
using MRL.Common;

namespace MRL.Model
{
    public class Device: PropertyChangedClass
    {
        private bool isselected;            //выбор
        private string name;                //наименование     
        private string use;                 //назначение   
        private string number;              //номер прибора        
        private string vernumber;           //номер поверки      
        private string verorganization;     //организация-поверитель  
        private DateTime verexpiration;     //срок действия поверки
        private string range;               //диапазон действия
        private string fault;               //погрешность

        public bool IsSelected
        {
            get { return isselected; }
            set
            {
                if (isselected != value)
                {
                    isselected = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("IsSelected"));
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Name"));
                }
            }
        }
        public string Use
        {
            get { return use; }
            set
            {
                if (use != value)
                {
                    use = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Use"));
                }
            }
        }
        public string Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Number"));
                }
            }
        }
        public string VerNumber
        {
            get { return vernumber; }
            set
            {
                if (vernumber != value)
                {
                    vernumber = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("VerNumber"));
                }
            }
        }
        public string VerOrganization
        {
            get { return verorganization; }
            set
            {
                if (verorganization != value)
                {
                    verorganization = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("VerOrganization"));
                }
            }
        }
        public DateTime VerExpiration
        {
            get { return verexpiration; }
            set
            {
                if (verexpiration != value)
                {
                    verexpiration = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("VerExpiration"));
                }
            }
        }
        public string Range
        {
            get { return range; }
            set
            {
                if (range != value)
                {
                    range = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Range"));
                }
            }
        }
        public string Fault
        {
            get { return fault; }
            set
            {
                if (fault != value)
                {
                    fault = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Fault"));
                }
            }
        }

    }

    public class Devices: RangedObservableCollection<Device>
    {
        public Devices()
        {

        }
    }
}
