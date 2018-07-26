namespace MRL.Model
{
    public class ObjectInfo
    {
        public string ObjectName { get; set; }       //объект для актов
        public string ObjectAddress { get; set; }    //адрес объекта
        public string Measurement { get; set; }      //размера объекта
        public string Purpose { get; set; }          //назначение объекта
        public string CustomerName { get; set; }     //заказчик
        public string CustomerAddress { get; set; }  //адрес заказчика
        public string Order { get; set; }            //номер договора
    }
}
