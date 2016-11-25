using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response.Message
{
    [Serializable]
    public class QuickReplyMessageResponse : BaseMessageResponse
    {
        #region Constructor

        public QuickReplyMessageResponse()
        {
            SetMessageType();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Quick replies title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Array of strings corresponding to quick replies.
        /// </summary>
        public string[] Replies { get; set; }

        #endregion

        #region MessageResponse Members

        public override void SetMessageType()
        {
            this.Type = Enum.Type.Text;
        }

        #endregion
    }
}
