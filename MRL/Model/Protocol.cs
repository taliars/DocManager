

namespace MRL.Model
{
    //описание протокола
    public class Protocol
    {
        public string Species { get; set; }         //вид протокола
        public string Name { get; set; }            //наименование протокола
        public string Date { get; set; }            //дата протокола
        public string Dates { get; set; }           //даты измерений
        public string Perfomer { get; set; }        //исполнитель
    }     
}
