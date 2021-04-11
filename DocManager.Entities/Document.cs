using System;

namespace DocManager.Entities
{
    public class Document
    {
        public string Species { get; set; }

        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public Device[] Devices { get; set; }

        public WeatherDay[] WeatherDays { get; set; }

        public Person Perfomer { get; set; }
    }
}
