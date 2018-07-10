using System.Collections.Generic;
using System.ComponentModel;
using MRL.Common;

namespace MRL.Model
{
    public class ObjectInfo
    {
        //private string objectname ;            //объект для актов
        //private string objectaddress ;       //адрес объекта
        //private string measurement ;  //размера объекта
        //private string purpose ;    //назначение объекта
        //private string customername ;        //заказчик
        //private string customeraddress ;     //адрес заказчика
        //private string order ;  //номер договора


        public string ObjectName { get; set; }
        public string ObjectAddress { get; set; }
        public string Measurement { get; set; }
        public string Purpose { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Order { get; set; }
        public Protocols Protocols { get; set; }
        public Acts Acts { get; set; }
        public WeatherDays WeatherDays { get; set; }

        public ObjectInfo()
        {
            Protocols = new Protocols();
            Acts = new Acts();
            WeatherDays = new WeatherDays();
        }
    }
}
