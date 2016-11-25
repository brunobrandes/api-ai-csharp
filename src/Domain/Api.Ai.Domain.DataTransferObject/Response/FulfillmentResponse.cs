using Api.Ai.Domain.DataTransferObject.Response.Message;
using Api.Ai.Domain.DataTransferObject.Serializer.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response
{
    [Serializable]
    public class FulfillmentResponse
    {
        #region Public Properties

        /// <summary>
        /// ext to be pronounced to the user / shown on the screen
        /// </summary>
        public string Speech { get; set; }

        /// <summary>
        /// Array of message objects
        /// </summary>       
        [JsonConverter(typeof(MessageResponseConverter))]
        public BaseMessageResponse[] Messages { get; set; }
        
        #endregion

    }
}
