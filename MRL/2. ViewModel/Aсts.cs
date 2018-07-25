using System;
using System.ComponentModel;
using MRL.Model;

namespace MRL.ViewModel
{
    public class ActViewModel: PropertyChangedClass
    {
        private readonly Act _act;

        public Act Act
        { 
            get => _act; 
        }

        public string Species
        {
            get => Act.Species;
            set { Act.Species = value; NotifyPropertyChanged("Species"); }
        }

        public string Name
        {
            get => Act.Name;
            set { Act.Name = value; NotifyPropertyChanged("Name"); }            
        }

        public string Date
        {
            get => Act.Date;            
            set { Act.Date = value; NotifyPropertyChanged("Date"); }
        }

        public string Dates
        {
            get => Act.Dates;
            set { Act.Date = value; NotifyPropertyChanged("Dates"); }
        }

        public string Perfomer
        {
            get => Act.Perfomer;           
            set { Act.Perfomer = value; NotifyPropertyChanged("Perfomer"); }
        }
        
        public ActViewModel(Act act)
        {
            _act = act;
        }        
    }
}
