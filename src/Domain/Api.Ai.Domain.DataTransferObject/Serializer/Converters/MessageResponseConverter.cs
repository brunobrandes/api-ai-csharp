using Api.Ai.Domain.DataTransferObject.Response.Message;
using Api.Ai.Domain.Enum;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Serializer.Converters
{
    public class MessageResponseConverter : JsonCreationConverter<BaseMessageResponse[]>
    {
        #region JsonCreationConverter Members

        protected override BaseMessageResponse[] Create(System.Type objectType, JObject jObject)
        {
            BaseMessageResponse[] result = null;

            var jResult = jObject["result"];

            if (jResult != null)
            {
                var jFulfillment = jResult["fulfillment"];

                if (jFulfillment != null)
                {
                    var messages = jFulfillment["messages"].ToString();

                    if (!string.IsNullOrWhiteSpace(messages))
                    {
                        var jArray = JArray.Parse(messages);

                        if (jArray != null && jArray.Count() > 0)
                        {
                            result = new BaseMessageResponse[jArray.Count()];

                            var i = 0;

                            foreach (JObject jObj in jArray.Children<JObject>())
                            {
                                var messageType = (Domain.Enum.Type)System.Enum.Parse(typeof(Domain.Enum.Type), jObj["type"].ToString());

                                switch (messageType)
                                {
                                    case Domain.Enum.Type.Text:
                                        result[i] = new TextMessageResponse();
                                        break;

                                    case Domain.Enum.Type.Card:
                                        result[i] = new CardMessageResponse();
                                        break;

                                    case Domain.Enum.Type.QuickReply:
                                        result[i] = new QuickReplyMessageResponse();
                                        break;

                                    case Domain.Enum.Type.Image:
                                        result[i] = new ImageMessageResponse();
                                        break;

                                    default:
                                        result[i] = null;
                                        break;
                                }

                                i++;
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion

    }
}
