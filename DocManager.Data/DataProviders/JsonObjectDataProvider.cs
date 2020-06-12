using DocManager.Core;
using DocManager.Data.Json;

namespace DocManager.Data.DataProviders
{
    public class JsonDataProvider : DataProviderBase, IObjectDataProvider
    {
        public JsonDataProvider(string name)
        {
            fullPath = WorkingFolderPath($"{name}.json");
            ObjectData = JsonReader.Deserialize<ObjectData>(fullPath);
        }

        public ObjectData ObjectData { get; }

        public void Save(ObjectData objectData)
        {
            JsonReader.Serialize(objectData, fullPath);
        }
    }
}
