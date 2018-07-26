using System.Collections.Generic;

namespace MRL.Model
{
    //информация об объекте
    public class ObjectData
    {
        public string ObjectName { get; set; }              //объект для актов
        public string ObjectAddress { get; set; }           //адрес объекта
        public string Measurement { get; set; }             //размера объекта
        public string Purpose { get; set; }                 //назначение объекта
        public string CustomerName { get; set; }            //заказчик
        public string CustomerAddress { get; set; }         //адрес заказчика
        public string Order { get; set; }                   //номер договора
        public List<Act> Acts { get; set; }                 //список акты в заказе
        public List<Protocol> Protocols { get; set; }       //список протоколы в заказе
        public List<WeatherDay> WeatherDays { get; set; }   //список дней погоды
    }
}
