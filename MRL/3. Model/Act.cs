using MRL.Common;
using System;

namespace MRL.Model
{
    public class Act: PropertyChangedClass
    {
        protected string _species;                  //вид  
        protected string _name;                     //наименование акта
        protected string _date;                     //дата акта
        protected string _dates;                    //даты, фигурирующие в акте
        protected string _perfomer;                 //исполнитель
    }
}


