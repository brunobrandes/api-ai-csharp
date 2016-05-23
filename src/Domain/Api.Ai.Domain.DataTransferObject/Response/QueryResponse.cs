using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Response
{
    public class QueryResponse : ResponseBase
    {
        #region Public Properties

        public QueryResult Result { get; set; }

        #endregion
    }

    public class QueryResult
    {
        #region Public Properties

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

        #endregion

        #region Public Methods

        /// <summary>
        /// Get context by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Context GetContextByName(string name)
        {
            if (this.Contexts == null || this.Contexts.Count() == 0)
            {
                throw new NullReferenceException("Contexts is null or empty.");
            }

            var context = this.Contexts.Where(x => x.Name == name).FirstOrDefault();

            if (context == null)
            {
                throw new KeyNotFoundException($"Context '{name}' not found.");
            }

            return context;
        }

        /// <summary>
        /// Get parameter value in context (name) by key
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetContextParameterValueByNameKey(string name, string key)
        {
            var context = GetContextByName(name);

            var result = string.Empty;

            if (!context.Parameters.TryGetValue(key, out result))
            {
                throw new KeyNotFoundException($"Context '{name}' and parameter key '{key}' not found.");
            }
            
            return result;
        }

        /// <summary>
        /// Get parameter value by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetParameterValueByKey(string key)
        {
            if (this.Contexts == null || this.Contexts.Count() == 0)
            {
                throw new NullReferenceException("Contexts is null or empty.");
            }

            var result = string.Empty;

            foreach (var context in this.Contexts)
            {
                if (context.Parameters.TryGetValue(key, out result))
                {
                    return result;
                }
            }

            throw new KeyNotFoundException($"Parameter '{key}' not found.");
        }

        #endregion
    }
}
