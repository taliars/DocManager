using DocManager.Core;
using DocManager.Data.Json;

namespace DocManager.Data.DataProviders
{
    public class JsonDataProvider : DataProviderBase, IOrderDataProvider
    {
        public JsonDataProvider(string name)
        {
            fullPath = WorkingFolderPath($"{name}.json");
            OrderData = JsonReader.Deserialize<OrderData>(fullPath);
        }

        public OrderData OrderData { get; }

        public void Save()
        {
            JsonReader.Serialize(OrderData, fullPath);
        }
    }
}
