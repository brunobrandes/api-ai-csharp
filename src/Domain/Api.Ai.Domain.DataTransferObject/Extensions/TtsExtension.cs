using Api.Ai.Domain.DataTransferObject.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.DataTransferObject.Extensions
{
    public static class TtsExtension
    {
        public static string ToQueryString(this TtsRequest ttsRequest)
        {
            string result = $"/tts?v={ttsRequest.V}";

            if (string.IsNullOrEmpty(ttsRequest.Text))
            {
                throw new ArgumentNullException("Query string 'query' is null or empty.");
            }
            
            return result += $"&text={ttsRequest.Text}"; 
        }
    }
}
