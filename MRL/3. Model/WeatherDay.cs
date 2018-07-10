using System;
using MRL.Common;

namespace MRL.Model
{
    public class WeatherDay : PropertyChangedClass
    {
        public bool IsSelected { get; set; }
        public DateTime Date { get; set; }
        public string Temperature { get; set; }
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public int Cloudness { get; set; }
        public int Pressure { get; set; }
        public int Moisture { get; set; }     
        
        public WeatherDay()
        {
            
        }        
    }

    public class WeatherDays : RangedObservableCollection<WeatherDay>
    {
        public WeatherDays()
        {
            this.Add(new WeatherDay
            {
                IsSelected = true,
                Date = DateTime.Now,
                Temperature = "+12",
                WindDirection = "ССВ",
                WindSpeed = 2,
                Cloudness = 10,
                Pressure = 766,
                Moisture = 98,
            }
                );
        }

        public void AddDay()
        {
            WeatherDay newDay;

            if (this.Count != 0)
            {
                WeatherDay lastday = this[this.Count - 1];
                newDay = new WeatherDay
                {
                    IsSelected = false,
                    Date = lastday.Date.AddDays(1),
                    Temperature = lastday.Temperature,
                    WindDirection = lastday.WindDirection,
                    WindSpeed = lastday.WindSpeed,
                    Cloudness = lastday.Cloudness,
                    Pressure = lastday.Pressure,
                    Moisture = lastday.Moisture,
                };
            }
            else
            {
                newDay = new WeatherDay
                {
                    IsSelected = false,
                    Date = DateTime.Now.AddDays(-1),
                    Temperature = "+10",
                    WindDirection = "C",
                    WindSpeed = 0,
                    Cloudness = 0,
                    Pressure = 760,
                    Moisture = 75,
                };
            }

            this.Add(newDay);
        }
    }
}
