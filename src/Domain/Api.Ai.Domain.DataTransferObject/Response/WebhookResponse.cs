using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response
{
    public class WebhookResponse
    {
        /// <summary>
        /// Voice response to the request.
        /// </summary>
        public string Speech { get; set; }

        /// <summary>
        /// Text displayed on the user device screen.
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// Additional data required for performing the action on the client side.
        /// The data is sent to the client in the original form and is not processed by Api.ai.
        /// </summary>
        public Dictionary<string, object> Data { get; set; }

        /// <summary>
        /// Array of context objects set after intent completion.
        /// </summary>
        public Context[] ContextOut { get; set; }

        /// <summary>
        /// Data source
        /// </summary>
        public string Source { get; set; }

    }
}
