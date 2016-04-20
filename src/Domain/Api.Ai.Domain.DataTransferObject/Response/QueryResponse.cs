using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response
{
    public class QueryResponse : ResponseBase
    {
        public QueryResult Result { get; set; }
    }

    public class QueryResult
    {
        /// <summary>
        /// Source of the answer. Could be "agent" if the response was retrieved from the agent. 
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The query that was used to produce this result.
        /// </summary>
        public string ResolvedQuery { get; set; }

        /// <summary>
        /// Deprecated
        /// </summary>
        public string Speech { get; set; }

        /// <summary>
        /// Matching score for the intent
        /// </summary>
        public float Score { get; set; }

        /// <summary>
        /// An action to take.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Parameters to be used by the action.
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }


        /// <summary>
        /// Array of context objects with the fields "name", "parameters", "lifespan".
        /// </summary>
        public Context[] Contexts { get; set; }

        /// <summary>
        /// Data about fulfillment, speech, structured fulfillment data, etc.
        /// </summary>
        public FulfillmentResponse Fulfillment { get; set; }

        /// <summary>
        /// Contains data on intents and contexts.
        /// </summary>
        public MetadataResponse Metadata { get; set; }
    }
}
