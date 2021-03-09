using System;

namespace DocManager.Domain.Core.OrderEntities
{
    public class DbWeatherDay
    {
        public int Id { get; set; }

        public int SubscriptionId { get; set; }

        public DateTime? Date { get; set; }

        public string Temperature { get; set; }

        public WindDirection WindDirection { get; set; }

        public int? WindSpeed { get; set; }

        public int? Cloudness { get; set; }

        public int? Pressure { get; set; }

        public int? Moisture { get; set; }
    }
}