using System;

namespace MRL.Model
{
    public class WeatherDay
    {
        public bool IsSelected { get; set; }        //выбранный день
        public DateTime Date { get; set; }          //дата
        public string Temperature { get; set; }     //температура
        public string WindDirection { get; set; }   //направление ветра
        public int WindSpeed { get; set; }          //скорость ветра
        public int Cloudness { get; set; }          //облачность
        public int Pressure { get; set; }           //атмосферное давление
        public int Moisture { get; set; }           //влажность             
    }    
}
