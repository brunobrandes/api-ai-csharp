using Api.Ai.Domain.DataTransferObject.Serializer.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response.Message
{
    public class TextMessageResponse : BaseMessageResponse
    {
        #region Constructor

        public TextMessageResponse()
        {
            SetMessageType();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Agent's text reply. Line breaks are supported for Facebook Messenger, Kik, Slack, and Telegram one-click integrations.
        /// </summary>
        public string Speech { get; set; }

        #endregion
       
        #region MessageResponse Members

        public override void SetMessageType()
        {
            this.Type = Enum.Type.Text;
        }

        #endregion
    }
}
