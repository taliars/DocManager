using System;
using System.Collections.Generic;
using System.Xml.Linq;
using MRL.Model;

namespace MRL.Service
{
    /*public static class XML
    {
        private static string docpath;
        private static XDocument doc;
        private static XElement objectinfo;
        private static IEnumerable<XElement> elements;

        private static bool CheckFile() // существует ли файл
        {
            if (System.IO.File.Exists(docpath))
            {
                doc = XDocument.Load(docpath);
                return true;
            }
            else
            {
                doc = null;
                return false;
            }
        }
        
        public static void Read(ObjectInfo o)
        {        
            docpath = System.IO.Directory.GetCurrentDirectory() + "\\xml\\001.xml";

            CheckFile();

            objectinfo = doc.Element("root").Element("ObjectInfo");

            o.ObjectName = objectinfo.Element("ObjectName").Value.ToString();
            o.ObjectAddress = objectinfo.Element("CustomerAddress").Value.ToString();
            o.Measurement = objectinfo.Element("Measurement").Value.ToString();
            o.Purpose = objectinfo.Element("Purpose").Value.ToString();
            o.CustomerAddress = objectinfo.Element("CustomerAddress").Value.ToString();
            o.CustomerName = objectinfo.Element("CustomerName").Value.ToString();
            o.Order = objectinfo.Element("Order").Value.ToString();

            ReadProtocols(o.Protocols);
            ReadActs(o.Acts);
        }
        
        private static void WeatherDays(WeatherDays w)
        {
            elements = objectinfo.Element("WeatherDays").Elements("WeatherDay");

            foreach (XElement e in elements)
            {
                w.Add(new WeatherDay
                {
                    Date = (DateTime)e.Element("Date"),
                    Temperature = e.Element("Temperature").Value,
                    WindDirection = e.Element("WindDirection").Value,
                    WindSpeed = (int)e.Element("WindSpeed"),
                    Cloudness = (int)e.Element("Cloudness"),
                    Pressure = (int)e.Element("Pressure"),
                    Moisture = (int)e.Element("Moisture")
                });
            }                
        }

        private static void ReadProtocols(Protocols p)
        {
            elements = objectinfo.Element("Protocols").Elements("Protocol");

            foreach (XElement e in elements)
            {
                p.Add(new Protocol
                {
                    Species = e.Element("Species").Value,
                    Name = e.Element("Name").Value,
                    Dates = e.Element("Dates").Value,
                    Date = e.Element("Date").Value,
                    Perfomer = e.Element("Perfomer").Value,
                });
            }
        }

        private static void ReadActs(Acts a)
        {
            elements = objectinfo.Element("Acts").Elements("Act");

            foreach (XElement e in elements)
            {
                a.Add(new Act
                {
                    Species = e.Element("Species").Value,
                    Name = e.Element("Name").Value,
                    Date = e.Element("Date").Value,
                    Dates = e.Element("Dates").Value,
                    Perfomer = e.Element("Perfomer").Value,
                });
            }  
        }

        public static void ReadDevices(Devices devices)
        {
            docpath = System.IO.Directory.GetCurrentDirectory() + "\\xml\\devices.xml";
            doc = XDocument.Load(docpath);

            elements = doc.Element("Devices").Elements("Device");

            foreach (XElement e in elements)
            {   
                devices.Add(new Device
                {
                    IsSelected = (bool)e.Element("IsSelected"),
                    Name = e.Element("Name").Value,
                    Use = e.Element("Use").Value,
                    Number = e.Element("Number").Value,
                    VerNumber = e.Element("VerNumber").Value,
                    VerOrganization = e.Element("VerOrganization").Value,
                    VerExpiration = (DateTime)e.Element("VerExpiration"),
                    Range = e.Element("Range").Value,
                    Fault = e.Element("Fault").Value,
                });
            }
        }

        public static void Create()
        {
            XDocument doc = new XDocument(
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
    }*/
}
