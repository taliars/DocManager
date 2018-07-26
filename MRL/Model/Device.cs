using System;

namespace MRL.Model
{
    //описываем характеристики прибора
    public class Device
    {
        public bool IsSelected { get; set; }               //выбранный прибор из списка
        public string Name { get; set; }                   //наименование прибора    
        public string Use { get; set; }                    //назначение прибора
        public string Number { get; set; }                 //номер прибора   
        public string VerNumber { get; set; }              //номер поверки      
        public string VerOrganization { get; set; }        //организация-поверитель  
        public DateTime VerExpiration { get; set; }        //срок действия поверки
        public string Range { get; set; }                  //диапазон действия
        public string Fault { get; set; }                  //погрешность прибора
    }
}
