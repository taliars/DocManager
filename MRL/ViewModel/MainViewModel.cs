using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Data;

using MRL.Model;
using MRL.Service;
using MRL.Common;

namespace MRL.ViewModel
{
     public class MainViewModel : PropertyChangedClass
    {
        public ObjectInfo ObjectInfo { get; set; }
        public Devices Devices { get; set; }
        public ICollectionView DevicesView { get; set; }

        public ICommand CommandWriteWord { get; set; }
        public ICommand CommandAddDate { get; set; }
        public ICommand CommandDeleteDate { get; set; }
        public ICommand CommandAddProtocol { get; set; }

        private Protocol _selectedProtocol;
        public Protocol SelectedProtocol
        {
            get { return _selectedProtocol; }
            set
            {
                if (_selectedProtocol != value)
                {
                    _selectedProtocol = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("_selectedProtocol"));
                    DevicesView.Filter = i =>
                    {
                        Device device = i as Device;
                        return device.Use.ToLower().Contains(_selectedProtocol.Species) || 
                            device.Use.Equals("Метеорология",StringComparison.InvariantCultureIgnoreCase);
                    };
                }
            }
        }


        public Act selectedAct { get; set; }
        public WeatherDay selectedWeatherDay { get; set; }
        
        public MainViewModel()
        {

        }
    }
}
