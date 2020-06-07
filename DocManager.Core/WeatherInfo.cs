using System;

namespace DocManager.Core
{
    public class WeatherInfo
    {
        public bool IsSelected { get; set; }
        public DateTime Date { get; set; }
        public string Temperature { get; set; }
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public int Cloudness { get; set; }
        public int Pressure { get; set; }
        public int Moisture { get; set; }
    }
}