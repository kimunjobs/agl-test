using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Data
{
    public class JsonLocalSource<T> : IJsonSource<T> where T: class
    {
        private readonly string fileSystemPath;

        public JsonLocalSource(string fileSystemPath)
        {
            this.fileSystemPath = fileSystemPath;
        }

        public T Load()
        {
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new StringEnumConverter(false));

            using (var streamReader = new StreamReader(new FileStream(fileSystemPath, FileMode.Open)))
            {
                var jsonTextReader = new JsonTextReader(streamReader);
                var result = serializer.Deserialize<T>(jsonTextReader);
                return result;
            }
        }
    }
}