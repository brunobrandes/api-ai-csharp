using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response
{
    public class FulfillmentResponse
    {
        /// <summary>
        /// ext to be pronounced to the user / shown on the screen
        /// </summary>
        public string Speech { get; set; }

        /// <summary>
        /// Source of the fulfillment / data, e.g. "Wikipedia". Applies only when Domains are enabled for the agent
        /// </summary>
        public string Source { get; set; }
    }
}
