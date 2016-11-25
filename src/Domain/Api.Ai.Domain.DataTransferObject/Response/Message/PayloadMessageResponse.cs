using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response.Message
{
    /// <summary>
    /// Custom payload message object
    /// </summary>
    public class PayloadMessageResponse : BaseMessageResponse
    {
        #region Constructor

        public PayloadMessageResponse()
        {
            SetMessageType();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Developer defined JSON. It is sent without modifications
        /// </summary>
        public string Payload { get; set; }

        #endregion

        #region BaseMessageResponse Members

        public override void SetMessageType()
        {
            this.Type = Enum.Type.Payload;
        }

        #endregion
    }
}
