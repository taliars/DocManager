using DocManager.Domain.Core.UserEntities;
using System;
using System.Collections.Generic;

namespace DocManager.Domain.Core.OrderEntities
{
    public class Document
    {
        public int Id { get; set; }

        public string Species { get; set; }

        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public virtual ICollection<Device> Devices { get; set; }

        public virtual ICollection<WeatherDay> WeatherDays { get; set; }

        public int PerfomerId { get; set; }

        public virtual User Perfomer { get; set; }
    }
}