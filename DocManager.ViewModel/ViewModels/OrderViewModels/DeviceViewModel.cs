using DocManager.Core;
using DocManager.ViewModel.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace DocManager.ViewModel
{
    public class DeviceViewModel : PropertyChangedBase
    {
        private ObservableCollection<Device> devices;
        private Visibility faultVisibility;

        public ObservableCollection<Device> Devices
        {
            get => devices;
            set
            {
                devices = value;
                NotifyPropertyChanged(nameof(Devices));
            }
        }

        public Visibility FaultVisibility
        {
            get => faultVisibility;
            set
            {
                faultVisibility = value;
                NotifyPropertyChanged(nameof(FaultVisibility));
            }
        }

        public Device SelectedDevice { get; set; }

        public DeviceViewModel(IEnumerable<Device> devices)
        {
            FaultVisibility = Visibility.Hidden;
            this.devices = new ObservableCollection<Device>(devices);
        }
    }
}