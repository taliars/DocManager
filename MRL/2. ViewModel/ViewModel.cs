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
        public ObjectInfo objectInfo { get; set; }
        public Devices devices { get; set; }
        public ICollectionView devicesView { get; set; }

        public ICommand CommandWriteWord { get; set; }
        public ICommand CommandAddDate { get; set; }
        public ICommand CommandDeleteDate { get; set; }
        public ICommand CommandAddProtocol { get; set; }

        private Protocol selectedprotocol;
        public Protocol selectedProtocol
        {
            get { return selectedprotocol; }
            set
            {
                if (selectedprotocol != value)
                {
                    selectedprotocol = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("selectedProtocol"));
                    devicesView.Filter = i =>
                    {
                        Device device = i as Device;
                        return device.Use.ToLower().Contains(selectedprotocol.Species.ToLower()) || device.Use.ToLower() == "Метеорология".ToLower();
                    };
                }
            }
        }


        public Act selectedAct { get; set; }
        public WeatherDay selectedWeatherDay { get; set; }
        
        public MainViewModel()
        {
            objectInfo = new ObjectInfo(); 
            XML.Read(objectInfo);

            devices = new Devices();
            XML.ReadDevices(devices);

            devicesView = CollectionViewSource.GetDefaultView(devices);

            CommandAddDate = new RelayCommand(arg => objectInfo.WeatherDays.AddDay());
            CommandDeleteDate = new RelayCommand(arg => objectInfo.WeatherDays.Remove(selectedWeatherDay));
            CommandAddProtocol = new RelayCommand(arg => objectInfo.Protocols.AddNew(arg.ToString()));
        }
    }
}
