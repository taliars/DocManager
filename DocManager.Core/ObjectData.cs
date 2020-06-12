using System;
using System.Collections.Generic;

namespace DocManager.Core
{
    public class ObjectData
    {
        public string ObjectName { get; set; }
        public string ObjectAddress { get; set; }
        public string Measurement { get; set; }
        public string Purpose { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Order { get; set; }
        public IEnumerable<Act> Acts { get; set; }
        public IEnumerable<Protocol> Protocols { get; set; }
        public IEnumerable<Device> Devices { get; set; }
        public IEnumerable<WeatherDay> WeatherDays { get; set; }

        public string Comment { get; set; }
    }
}