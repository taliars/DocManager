using DocManager.Core;
using System.Collections.ObjectModel;

namespace DocManager.ViewModel
{
    public class InnerObjectDataViewModel
    {
        public string ObjectName { get; set; }
        public string ObjectAddress { get; set; }
        public string Measurement { get; set; }
        public string Purpose { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Order { get; set; }
        public ObservableCollection<Act> Acts { get; set; }
        public ObservableCollection<Protocol> Protocols { get; set; }
        public ObservableCollection<Device> Devices { get; set; }
        public ObservableCollection<WeatherDay> WeatherDays { get; set; }
        public string Comment { get; set; }
    }
}