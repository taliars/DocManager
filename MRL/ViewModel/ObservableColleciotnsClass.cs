using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRL.ViewModel
{
    class ObservableColleciotnsClass
    {
        public ObservableCollection<ActViewModel> acts = new ObservableCollection<ActViewModel>();
        public ObservableCollection<ProtocolViewModel> protocols = new ObservableCollection<ProtocolViewModel>();
        public ObservableCollection<DeviceViewModel> device = new ObservableCollection<DeviceViewModel>();
    }
}
