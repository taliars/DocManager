
using MRL.Model;

namespace MRL.ViewModel
{
    class ProtocolViewModel : PropertyChangedClass
    {
        private readonly Protocol protocol;


        public Protocol Protocol
        {
            get => protocol;
        }

        #region properties

        public string Species
        {
            get => Protocol.Species;
            set { Protocol.Species = value; NotifyPropertyChanged("Species"); }
        }

        public string Name
        {
            get => Protocol.Name;
            set { Protocol.Name = value; NotifyPropertyChanged("Name"); }
        }

        public string Date
        {
            get => Protocol.Date;
            set { Protocol.Date = value; NotifyPropertyChanged("Date"); }
        }

        public string Dates
        {
            get => Protocol.Dates;
            set { Protocol.Dates = value; NotifyPropertyChanged("Dates"); }
        }

        public string Perfomer
        {
            get => Protocol.Perfomer;
            set { Protocol.Perfomer = value; NotifyPropertyChanged("Perfomer"); }
        }

        #endregion

        public ProtocolViewModel(Protocol protocol)
        {
            this.protocol = protocol;
        }
            
            
    }
}
