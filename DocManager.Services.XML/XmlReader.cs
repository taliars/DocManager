using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DocManager.Core;

namespace DocManager.Services.XML
{
    // Maybe use expressions?
    public static class XmlReader
    {
        public static ObjectInfo ReadObjectInfo(string docPath)
        {
            var xmlObjectInfo = TryToGetXmlObjectInfo(docPath);

            return new ObjectInfo
            {
                ObjectName = xmlObjectInfo.Element("ObjectName")?.Value,
                ObjectAddress = xmlObjectInfo.Element("CustomerAddress")?.Value,
                Measurement = xmlObjectInfo.Element("Measurement")?.Value,
                Purpose = xmlObjectInfo.Element("Purpose")?.Value,
                CustomerAddress = xmlObjectInfo.Element("CustomerAddress")?.Value,
                CustomerName = xmlObjectInfo.Element("CustomerName")?.Value,
                Order = xmlObjectInfo.Element("Order")?.Value,
                Acts = xmlObjectInfo.GetData(GetDocuments<Act>),
                Protocols = xmlObjectInfo.GetData(GetDocuments<Protocol>),
                Devices = xmlObjectInfo.GetData(GetDevices),
                WeatherDays = xmlObjectInfo.GetData(GetWeatherDays),
            };
        }

        private static XElement TryToGetXmlObjectInfo(string docPath)
        {
            if (!System.IO.File.Exists(docPath))
            {
                throw new ArgumentException("Document doesn't exists");
            }

            var doc = XDocument.Load(docPath);

            var objectInfoNode = doc.Element("root")?.Element("ObjectInfo");

            if (objectInfoNode == null)
            {
                throw new Exception("The information about required object is broken or not accessable");
            }

            return objectInfoNode;
        }

        private static IEnumerable<T> GetData<T>(this XContainer root,
            Func<IEnumerable<XElement>, IEnumerable<T>> getDataFunc)
        {
            var xmlNodeNameDictionary = new Dictionary<Type, XmlPathNode>
            {
                [typeof(Act)] = new XmlPathNode {MainNode = "Acts", SubNode = "Act",},
                [typeof(Protocol)] = new XmlPathNode {MainNode = "Protocols", SubNode = "Protocol",},
                [typeof(WeatherInfo)] = new XmlPathNode {MainNode = "WeatherInfo", SubNode = "WeatherInfo",},
                [typeof(Device)] = new XmlPathNode {MainNode = "Devices", SubNode = "Device",}
            };

            var xmlNodeNames = xmlNodeNameDictionary[typeof(T)];
            var nodes = root.Element(xmlNodeNames.MainNode)?.Elements(xmlNodeNames.SubNode);
            return nodes == null ? null : getDataFunc.Invoke(nodes);
        }

        private static IEnumerable<T> GetDocuments<T>(IEnumerable<XElement> elements) where T : Document, new()
        {
            return elements?.Select(e => new T
                {
                    Species = e.Element("Species")?.Value,
                    Name = e.Element("Name")?.Value,
                    Date = e.Element("Date")?.Value,
                    Dates = e.Element("Dates")?.Value,
                    Perfomer = e.Element("Perfomer")?.Value
                })
                .ToList();
        }


        private static IEnumerable<Device> GetDevices(IEnumerable<XElement> elements)
        {
            return elements?.Select(e => new Device
            {
                IsSelected = (bool) e.Element("IsSelected"),
                Name = e.Element("Name")?.Value,
                Use = e.Element("Use")?.Value,
                Number = e.Element("Number")?.Value,
                VerNumber = e.Element("VerNumber")?.Value,
                VerOrganization = e.Element("VerOrganization")?.Value,
                VerExpiration = (DateTime) e.Element("VerExpiration"),
                Range = e.Element("Range")?.Value,
                Fault = e.Element("Fault")?.Value,
            });
        }

        private static IEnumerable<WeatherInfo> GetWeatherDays(IEnumerable<XElement> elements)
        {
            return elements?.Select(e => new WeatherInfo
            {
                Date = (DateTime) e.Element("Date"),
                Temperature = e.Element("Temperature")?.Value,
                WindDirection = e.Element("WindDirection")?.Value,
                WindSpeed = (int) e.Element("WindSpeed"),
                Cloudness = (int) e.Element("Cloudness"),
                Pressure = (int) e.Element("Pressure"),
                Moisture = (int) e.Element("Moisture")
            });
        }

        private class XmlPathNode
        {
            public string MainNode { get; set; }

            public string SubNode { get; set; }
        }
    }
}