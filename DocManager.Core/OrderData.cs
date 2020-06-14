﻿using System.Collections.Generic;

namespace DocManager.Core
{
    public class OrderData
    {
        public ObjectData ObjectData { get; set; }
        public IEnumerable<Act> Acts { get; set; }
        public IEnumerable<Protocol> Protocols { get; set; }
        public IEnumerable<Device> Devices { get; set; }
        public IEnumerable<WeatherDay> WeatherDays { get; set; }
    }
}
