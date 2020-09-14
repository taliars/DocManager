using DocManager.Core;
using DocManager.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DocManager.Data.Json
{
    public class JsonOrderData : IOrderData
    {
        private readonly string sourceFolderPath;

        public JsonOrderData(string sourceFolderPath)
        {
            this.sourceFolderPath = sourceFolderPath;
        }

        public Order Add(Order order)
        {
            int maxOrderId = GetOrderIds.Any() ? GetOrderIds.Max() : 0;
            order.Id = maxOrderId + 1;
            Serialize(order, sourceFolderPath.ToFullPath(order.Id));
            return order;
        }

        public Order Delete(int id)
        {
            FileService.Delete(sourceFolderPath.ToFullPath(id));
            return new Order();
        }

        public Order GetById(int id)
        {
            var path = sourceFolderPath.ToFullPath(id);

            if (!File.Exists(path))
            {
                return null;
            }

            var order = Deserialize<Order>(path);

            var devicePath = sourceFolderPath.ToFullPath("devices");

            if (File.Exists(path))
            {
                try
                {
                    order.Devices = Deserialize<IEnumerable<Device>>(sourceFolderPath.ToFullPath("devices"));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
   
            order.Id = id;
            return order;

        }

        public Order Update(Order order)
        {
            Serialize(order, sourceFolderPath.ToFullPath(order.Id));
            return order;
        }

        private IEnumerable<int> GetOrderIds
        {
            get
            {
                var result = new List<int>();

                var allFiles = Directory.GetFiles(sourceFolderPath);
                
                foreach (var file in allFiles)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    var isParsed = int.TryParse(fileName, out var parsedValue);
                    if (isParsed)
                    {
                        result.Add(parsedValue);
                    }
                }
                return result;
            }
        }

        public List<OrderTuple> GetGetOrderNames()
        {
            if (!File.Exists(sourceFolderPath))
            {
                return new List<OrderTuple>();
            }

            var result = new List<OrderTuple>();

            var allFiles = Directory.GetFiles(sourceFolderPath);

            foreach (var file in allFiles)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var isParsed = int.TryParse(fileName, out var parsedId);
                if (isParsed)
                {
                    result.Add(
                        new OrderTuple
                        {
                            Id = parsedId,
                            Name = Deserialize<Order>(file).ObjectData?.Order,
                        });
                }
            }
            return result;
        }

        public int Commit()
        {
            return 0;
        }

        private static void Serialize<T>(T model, string path)
        {
            var result = JsonConvert.SerializeObject(model);
            File.WriteAllText(path, result);
        }

        private static T Deserialize<T>(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("Document doesn't exists");
            }

            var content = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
