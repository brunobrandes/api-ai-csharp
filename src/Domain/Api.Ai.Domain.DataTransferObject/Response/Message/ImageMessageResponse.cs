using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response.Message
{
    [Serializable]
    public class ImageMessageResponse : BaseMessageResponse
    {
        #region Constructor

        public ImageMessageResponse()
        {
            SetMessageType();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Public URL to the image file.
        /// </summary>
        public string ImageUrl { get; set; }

        #endregion

        #region MessageResponse Members

        public override void SetMessageType()
        {
            this.Type = (int)Enum.Type.Text;
        }

        #endregion
    }
}
