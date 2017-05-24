using Api.Ai.Domain.DataTransferObject.Response.Message;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Ai.Domain.DataTransferObject.Serializer;

namespace Api.Ai.Domain.DataTransferObject.Serializer.Converters
{
    public class MessageCollectionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BaseMessageResponse[]);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            BaseMessageResponse[] result = null;

            var jArray = JArray.Load(reader);

            if (jArray != null)
            {
                result = new BaseMessageResponse[jArray.Count];

                for (var i = 0; i < jArray.Count; i++)
                {
                    var messageType = (Domain.Enum.Type)System.Enum.Parse(typeof(Domain.Enum.Type), jArray[i]["type"].ToString());

                    switch (messageType)
                    {
                        case Domain.Enum.Type.Text:
                            result[i] = ApiAiJson<TextMessageResponse>.Deserialize(jArray[i].ToString());
                            break;

                        case Domain.Enum.Type.Card:
                            result[i] = ApiAiJson<CardMessageResponse>.Deserialize(jArray[i].ToString());
                            break;

                        case Domain.Enum.Type.QuickReply:
                            result[i] = ApiAiJson<QuickReplyMessageResponse>.Deserialize(jArray[i].ToString());
                            break;

                        case Domain.Enum.Type.Image:
                            result[i] = ApiAiJson<ImageMessageResponse>.Deserialize(jArray[i].ToString());
                            break;

                        case Domain.Enum.Type.Payload:
                            result[i] = ApiAiJson<PayloadMessageResponse>.Deserialize(jArray[i].ToString());
                            break;

                        default:
                            result[i] = null;
                            break;
                    }
                }
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, (BaseMessageResponse[])value);
        }
    }
}
