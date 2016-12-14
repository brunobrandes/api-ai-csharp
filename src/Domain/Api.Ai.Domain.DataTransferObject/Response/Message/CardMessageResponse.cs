using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response.Message
{
    [Serializable]
    public class CardMessageResponse : BaseMessageResponse
    {
        #region Constructor

        public CardMessageResponse()
        {
            SetMessageType();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Card title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Card subtitle.
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Array of objects corresponding to card buttons.
        /// </summary>
        public CardMessageResponseButton[] Buttons { get; set; }


        #endregion

        #region MessageResponse Members

        public override void SetMessageType()
        {
            this.Type = (int)Enum.Type.Text;
        }

        #endregion
    }

    /// <summary>
    ///  Card buttons.
    /// </summary>
    public class CardMessageResponseButton
    {
        /// <summary>
        /// Button text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// A text sent back to API.AI or a URL to open.
        /// </summary>
        public string Postback { get; set; }
    }

}
