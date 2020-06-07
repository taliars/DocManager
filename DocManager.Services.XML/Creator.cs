using System.Xml.Linq;

namespace DocManager.Services.XML
{
    public class Creator
    {
        public static void Create()
        {
            var doc = new XDocument(
                new XElement("root",
                    new XElement("ObjectInfo",
                        new XElement("ObjectName", "Наименование объекта"),
                        new XElement("ObjectAddress", "Адрес объекта"),
                        new XElement("Measurament", "Измерение объекта"),
                        new XElement("Purpose", "Цель"),
                        new XElement("Customer", "Заказчик"),
                        new XElement("CustomerAddress", "Адрес заказчика"),
                        new XElement("Order", "Договор номер"))));

            doc.Save(System.IO.Directory.GetCurrentDirectory() + "\\xml\\002.xml");
        }
    }
}