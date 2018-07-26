using MRL.Model;
using System.Collections.ObjectModel;

namespace MRL.ViewModel
{
    public class ActViewModel: PropertyChangedClass
    {
        private readonly Act act;

        public Act Act
        { 
            get => act; 
        }

        #region properties

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

        #endregion

        public ActViewModel(Act act)
        {
            this.act = act;
        }        
    }

    public class BookProvider
    {
        public ObservableCollection<ActViewModel> GetActs()
        {
            ObservableCollection<ActViewModel> acts = new ObservableCollection<ActViewModel>
            {
                new ActViewModel(new Act
                {
                    
                }),

                new ActViewModel(new Act
                {
                   
                })
            };

            return acts;
        }
    }
}
