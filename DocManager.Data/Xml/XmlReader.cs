using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DocManager.Core;

namespace DocManager.Data.Xml
{
    internal static class XmlReader
    {
        public static ObjectData ReadObjectInfo(string docPath)
        {
            var xmlObjectInfo = TryToGetXmlObjectInfo(docPath);

            return new ObjectData
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
                Comment = xmlObjectInfo.Element("Comment")?.Value,
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
                [typeof(Act)] = new XmlPathNode { MainNode = "Acts", SubNode = "Act", },
                [typeof(Protocol)] = new XmlPathNode { MainNode = "Protocols", SubNode = "Protocol", },
                [typeof(WeatherDay)] = new XmlPathNode { MainNode = "WeatherDays", SubNode = "WeatherDay", },
                [typeof(Device)] = new XmlPathNode { MainNode = "Devices", SubNode = "Device", }
            };

            var xmlNodeNames = xmlNodeNameDictionary[typeof(T)];
            var nodes = root.Element(xmlNodeNames.MainNode)?.Elements(xmlNodeNames.SubNode);
            return nodes == null ? null : getDataFunc.Invoke(nodes);
        }

        private static IEnumerable<T> GetDocuments<T>(IEnumerable<XElement> elements) where T : Document, new()
        {
            return elements?.Select(e => new T
            {
                Species = e.GetOrNull(nameof(Document.Species)),
                Name = e.GetOrNull(nameof(Document.Name)),
                Date = DateTime.Parse(e.GetOrNull(nameof(Document.Date))),
                Dates = e.GetOrNull(nameof(Document.Dates)),
                Perfomer = e.GetOrNull(nameof(Document.Perfomer)),
            })
                .ToList();
        }


        private static IEnumerable<Device> GetDevices(IEnumerable<XElement> elements)
        {
            return elements?.Select(e => new Device
            {
                IsSelected = (bool)e.Element("IsSelected"),
                Name = e.GetOrNull(nameof(Device.Name)),
                Use = e.GetOrNull(nameof(Device.Use)),
                Number = e.GetOrNull(nameof(Device.Number)),
                VerNumber = e.GetOrNull(nameof(Device.VerNumber)),
                VerOrganization = e.GetOrNull(nameof(Device.VerOrganization)),
                VerExpiration = (DateTime)e.Element("VerExpiration"),
                Range = e.GetOrNull(nameof(Device.Range)),
                Fault = e.GetOrNull(nameof(Device.Fault)),
            });
        }

        private static IEnumerable<WeatherDay> GetWeatherDays(IEnumerable<XElement> elements)
        {
            return elements?.Select(e => new WeatherDay
            {
                // Date = (DateTime)e.Element("Date"),
                Temperature = e.GetOrNull(nameof(WeatherDay.Temperature)),
                WindDirection = e.GetOrNull(nameof(WeatherDay.WindDirection)),
                WindSpeed = e.TryParseToInt(nameof(WeatherDay.WindSpeed)),
                Cloudness = e.TryParseToInt(nameof(WeatherDay.Cloudness)),
                Pressure = e.TryParseToInt(nameof(WeatherDay.Pressure)),
                Moisture = e.TryParseToInt(nameof(WeatherDay.Moisture)),
            });
        }

        private static int? TryParseToInt(this XContainer xContainer, string name)
        {
            try
            {
                var result = int.Parse(xContainer.Element(name)?.Value);
                return result;
            }
            catch
            {
                return (int?)null;
            }
        }

        private static string GetOrNull(this XContainer xContainer, string name) => xContainer.Element(name)?.Value;

        private class XmlPathNode
        {
            public string MainNode { get; set; }

            public string SubNode { get; set; }
        }
    }
}