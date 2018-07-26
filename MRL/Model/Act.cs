using MRL.Common;
using System;

namespace MRL.Model
{
    public class Act
    {
        public string Species { get; set; }                 //вид  
        public string Name { get; set; }                    //наименование акта
        public string Date { get; set; }                    //дата акта
        public string Dates { get; set; }                   //даты, фигурирующие в акте
        public string Perfomer { get; set; }                //исполнитель
    }
}


