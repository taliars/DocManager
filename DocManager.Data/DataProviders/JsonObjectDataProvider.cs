using DocManager.Core;
using DocManager.Data.Json;
using System.Collections.Generic;

namespace DocManager.Data.DataProviders
{
    public class JsonDataProvider : DataProviderBase, IOrderDataProvider
    {
        public JsonDataProvider(string orderDataFile, string devicePath)
        {
            objectDataPath = WorkingFolderPath($"{orderDataFile}.json");
            OrderData = JsonReader.Deserialize<OrderData>(objectDataPath);
            devicePath = WorkingFolderPath($"{devicePath}.json");
            OrderData.Devices = JsonReader.Deserialize<IEnumerable<Device>>(devicePath);
        }

        public void Save()
        {
            JsonReader.Serialize(OrderData, objectDataPath);
        }
    }
}
