using DocManager.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DocManager.ViewModel
{
    public class DeviceViewModel
    {
        private ObservableCollection<Device> devices;

        public DeviceViewModel(IEnumerable<Device> devices)
        {
            this.devices = new ObservableCollection<Device>(devices);
        }
    }
}