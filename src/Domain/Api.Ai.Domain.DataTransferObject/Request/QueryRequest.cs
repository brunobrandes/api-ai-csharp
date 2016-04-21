using Api.Ai.Domain.DataTransferObject.Request;
using Api.Ai.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Request
{
    public class QueryRequest : RequestBase
    {
        #region Public Properties

        /// <summary>
        /// The natural language text to be processed. The request can have multiple query parameters. 
        /// </summary>
        public string[] Query { get; set; }

        /// <summary>
        /// The confidence of the corresponding query parameter having been correctly recognized by a 
        /// speech recognition system. 0 represents no confidence and 1 represents the highest confidence. 
        /// </summary>
        public float[] Confidence { get; set; }

        /// <summary>
        /// A string token up to 36 symbols long, used to identify the client and to manage sessions parameters (including contexts) per client.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Language tag.
        /// </summary>
        public Language Lang { get; set; }

        /// <summary>
        /// Array of additional input context objects.
        /// </summary>
        public Context[] Contexts { get; set; }

        /// <summary>
        /// If true, all current contexts in a session will be reset before the new ones are set. False by default.
        /// </summary>
        public int ResetContexts { get; set; }

        /// <summary>
        /// Array of entities that replace developer defined entities for this request only. The entity(ies) need to exist in the developer console
        /// </summary>
        public EntityRequest[] Entities { get; set; }

        /// <summary>
        /// Time zone from IANA Time Zone Database. 
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// Latitude and longitude values.
        /// </summary>
        public LocationRequest Location { get; set; }

        #endregion
    }
}
