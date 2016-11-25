using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Serializer.Converters
{
    public abstract class JsonCreationArrayConverter<T> : JsonConverter
    {
        protected abstract T[] Create(Type objectType, JArray jArray);

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsSubclassOf(typeof(T));
        }

        //This method never gets called
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jArray = JArray.Load(reader);

            var target = Create(objectType, jArray);

            serializer.Populate(jArray.CreateReader(), target);

            return target;

        }

        //I just kinda guessed at this code
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (this.CanConvert(value.GetType()))
            {
                serializer.Serialize(writer, value);
            }
        }
    }
}
