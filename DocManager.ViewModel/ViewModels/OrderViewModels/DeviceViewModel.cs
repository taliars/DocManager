using DocManager.Core;
using DocManager.ViewModel.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace DocManager.ViewModel
{
    public class DeviceViewModel : PropertyChangedBase
    {
        public ObservableCollection<Device> Devices { get; set; }

        public Device SelectedDevice { get; set; }

        public DeviceViewModel(IEnumerable<Device> devices)
        {
            this.Devices = new ObservableCollection<Device>(devices);
        }
    }
}