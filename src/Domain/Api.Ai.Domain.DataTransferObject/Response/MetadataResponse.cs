using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response
{
    public class MetadataResponse
    {
        #region Public Properties

        /// <summary>
        /// ID of the intent that produced this result.
        /// </summary>
        public string IntentId { get; set; }


        public bool WebhookUsed { get; set; }

        /// <summary>
        /// Name of the intent that produced this result.
        /// </summary>
        public string IntentName { get; set; }

        #endregion
    }
}
