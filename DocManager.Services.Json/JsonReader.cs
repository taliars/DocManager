using Newtonsoft.Json;

namespace DocManager.Services.Json
{
    public static class JsonReader
    {
        public static void Serialize<T>(T model, string path)
        {
            var result = JsonConvert.SerializeObject(model);
            System.IO.File.WriteAllText(path, result);
        }

        public static T Deserialize<T>(string path)
        {
            var content = System.IO.File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
