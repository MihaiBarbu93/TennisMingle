using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.API.Extensions
{
    public static partial class JsonExtensions
    {
        public static T LoadFromFileWithGeoJson<T>(string path, JsonSerializerSettings settings = null)
        {
            var serializer = NetTopologySuite.IO.GeoJsonSerializer.CreateDefault(settings);
            serializer.CheckAdditionalContent = true;
            using (var textReader = new StreamReader(path))
            using (var jsonReader = new JsonTextReader(textReader))
            {
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
