using System;
using MRL.Common;

namespace MRL.Model
{
    //класс определяющий приборную базу 
    public class Device: PropertyChangedClass
    {
        protected bool _isselected;            //выбранный прибор из списка
        protected string _name;                //наименование прибора    
        protected string _use;                 //назначение прибора
        protected string _number;              //номер прибора   
        protected string _vernumber;           //номер поверки      
        protected string _verorganization;     //организация-поверитель  
        protected DateTime _verexpiration;     //срок действия поверки
        protected string _range;               //диапазон действия
        protected string _fault;               //погрешность прибора
    }
}
