using System;
using System.Collections.Generic;
using DocManager.Core.AuthEntities;

namespace DocManager.Core.OrderEntities
{
    public class DbDocument
    {
        public int Id { get; set; }

        public int SubscriptionId { get; set; }

        public string Species { get; set; }

        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public virtual ICollection<DbDevice> Devices { get; set; }

        public virtual ICollection<DbWeatherDay> WeatherDays { get; set; }

        public int PerfomerId { get; set; }

        public virtual DbPerson Perfomer { get; set; }
    }
}