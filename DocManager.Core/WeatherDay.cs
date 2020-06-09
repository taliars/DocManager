using System;

namespace DocManager.Core
{
    public class WeatherDay
    {
        public bool IsSelected { get; set; }
        public DateTime? Date { get; set; }
        public string Temperature { get; set; }
        public string WindDirection { get; set; }
        public int? WindSpeed { get; set; }
        public int? Cloudness { get; set; }
        public int? Pressure { get; set; }
        public int? Moisture { get; set; }

        public WeatherDay()
        {
            IsSelected = true;
            Date = DateTime.Now;
            Temperature = "0";
            WindDirection = "C";
            WindSpeed = 0;
            Cloudness = 0;
            Pressure = 768;
            Moisture = 50;
        }
    }
}