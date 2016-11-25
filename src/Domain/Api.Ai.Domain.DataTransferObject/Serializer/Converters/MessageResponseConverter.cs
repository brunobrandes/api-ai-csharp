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
    public class MessageResponseConverter : JsonCreationArrayConverter<BaseMessageResponse>
    {
        #region JsonCreationConverter Members

        protected override BaseMessageResponse[] Create(System.Type objectType, JArray jArray)
        {
            if (jArray == null)
            {
                return null;
            }

            var result = new BaseMessageResponse[jArray.Count];

            var i = 0;

            foreach (var jObject in jArray)
            {
                var messageType = (Enum.Type)System.Enum.Parse(typeof(Enum.Type), jObject["type"].ToString());

                switch (messageType)
                {
                    case Enum.Type.Text:
                        result[i] = new TextMessageResponse();
                        break;

                    case Enum.Type.Card:
                        result[i] = new CardMessageResponse();
                        break;

                    case Enum.Type.QuickReply:
                        result[i] = new QuickReplyMessageResponse();
                        break;

                    case Enum.Type.Image:
                        result[i] = new ImageMessageResponse();
                        break;

                    default:
                        return null;
                }

                i++;
            }

            return result;
        }

        #endregion

    }
}
