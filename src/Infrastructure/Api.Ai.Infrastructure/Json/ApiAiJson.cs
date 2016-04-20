using Api.Ai.Domain.Service.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Infrastructure.Json
{
    public class ApiAiJson<T> 
    {
        private static JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented
        };

        static ApiAiJson()
        {
            _settings.Converters.Add(new StringEnumConverter());
        }

        public static string Serialize(T t)
        {
            return JsonConvert.SerializeObject(t, _settings);
        }

        public static T Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _settings);
        }
    }
}
