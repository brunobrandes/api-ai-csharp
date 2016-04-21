using Api.Ai.Domain.DataTransferObject.Request;
using Api.Ai.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Extensions
{
    public static class QueryExtension
    {
        public static string ToQueryString(this QueryRequest queryRequest)
        {
            string result = $"/query?v={queryRequest.V}";

            if (queryRequest.Query == null)
            {
                throw new ArgumentNullException("Query string 'query' is null or empty.");
            }

            result += $"&query={queryRequest.Query.FirstOrDefault()}";

            if (!string.IsNullOrEmpty(queryRequest.Timezone))
            {
                result += $"&timezone={queryRequest.Timezone}";
            }

            result += $"&lang={queryRequest.Lang}";

            if (queryRequest.Contexts != null && queryRequest.Contexts.Count() > 0)
            {
                foreach (var context in queryRequest.Contexts)
                {
                    result += $"&contexts={context.Name}";
                }
            }

            if (queryRequest.Location != null)
            {
                if (!string.IsNullOrEmpty(queryRequest.Location.Latitude) && !string.IsNullOrEmpty(queryRequest.Location.Longitude))
                {
                    result += $"&latitude={queryRequest.Location.Latitude}&longitude={queryRequest.Location.Longitude}";
                }
            }

            if (!string.IsNullOrEmpty(queryRequest.SessionId))
            {
                result += $"&sessionId={queryRequest.SessionId}";
            }

            return result;
        }
    }
}
