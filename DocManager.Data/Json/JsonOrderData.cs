using DocManager.Core;
using DocManager.Services;
using System.Collections.Generic;

namespace DocManager.Data.Json
{
    public class JsonOrderData : IOrderData
    {
        private readonly string sourceFolderPath;

        public JsonOrderData(string sourceFolderPath)
        {
            this.sourceFolderPath = sourceFolderPath;
        }

        public IEnumerable<int> GetOrderIds => throw new System.NotImplementedException();

        public Order Add(Order order)
        {
            JsonReader.Serialize(order, sourceFolderPath.ToFullPath(order.Id));
            return order;
        }

        public int Commit()
        {
            return 0;
        }

        public Order Delete(int id)
        {
            FileService.Delete(sourceFolderPath.ToFullPath(id));
            return new Order();
        }

        public Order GetById(int id)
        {
            var order = new Order();
            order = JsonReader.Deserialize<Order>(sourceFolderPath.ToFullPath(id));
            order.Devices = JsonReader.Deserialize<IEnumerable<Device>>(sourceFolderPath.ToFullPath("devices"));
            order.Id = id;
            return order;
        }

        public Order Update(Order order)
        {
            JsonReader.Serialize(order, sourceFolderPath.ToFullPath(order.Id));
            return order;
        }
    }
}
