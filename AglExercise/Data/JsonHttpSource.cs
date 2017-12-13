using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Data
{
    public class JsonHttpSource<T> : IJsonSource<T> where T: class
    {
        private Uri uri;

        public JsonHttpSource(Uri uri)
        {
            this.uri = uri;
        }

        public T Load()
        {
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new StringEnumConverter(false));

            using (var httpClient = new HttpClient())
            {
                // I know using Result can cause deadlock in a real app and we should be async all the way up
                var resultStream = httpClient.GetStreamAsync(this.uri).Result;

                using (var streamReader = new StreamReader(resultStream))
                {
                    var jsonTextReader = new JsonTextReader(streamReader);
                    var result = serializer.Deserialize<T>(jsonTextReader);
                    return result;
                }

            }
        }
    }
}