using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocManager.Core;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel.ViewModels
{
    public class DevicesViewModel : PropertyChangedBase
    {

        private Device selectedDevice;

        public ObservableCollection<Device> Devices { get; set; }




        public Device SelectedDevice
        {
            get => selectedDevice;
            set
            {
                selectedDevice = value;
                NotifyPropertyChanged(nameof(SelectedDevice));
            }
        }

        public DevicesViewModel()
        {

        }
    }
}
