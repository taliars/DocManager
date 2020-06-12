using Newtonsoft.Json;
using System;
using System.IO;

namespace DocManager.Data.Json
{
    internal static class JsonReader
    {
        public static void Serialize<T>(T model, string path)
        {
            var result = JsonConvert.SerializeObject(model);
            File.WriteAllText(path, result);
        }

        public static T Deserialize<T>(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                throw new ArgumentException("Document doesn't exists");
            }

            var content = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
