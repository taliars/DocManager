using System;

namespace DocManager.Entities
{
    public class WeatherDay
    {

        public DateTime? Date { get; set; }

        public string Temperature { get; set; }

        public WindDirection WindDirection { get; set; }

        public int? WindSpeed { get; set; }

        public int? Cloudness { get; set; }

        public int? Pressure { get; set; }

        public int? Moisture { get; set; }

    }
}
