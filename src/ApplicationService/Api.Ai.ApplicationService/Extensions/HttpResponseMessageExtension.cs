using Api.Ai.Domain.DataTransferObject.Response;
using Api.Ai.Domain.DataTransferObject.Serializer;
using Api.Ai.Domain.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Ai.ApplicationService.Extensions
{
    public static class HttpResponseMessageExtension
    {
        #region Private Methods

        private static async Task ValidateResponse(HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                var errorDetails = string.Empty;

                if (httpResponseMessage.Content != null)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(content))
                    {
                        try
                        {
                            var queryResponse = ApiAiJson<QueryResponse>.Deserialize(content);

                            if (queryResponse != null && queryResponse.Status != null && !string.IsNullOrEmpty(queryResponse.Status.ErrorDetails))
                            {
                                errorDetails = queryResponse.Status.ErrorDetails;
                            }
                        }
                        catch { }
                    }
                }

                throw new ApiAiException(httpResponseMessage.StatusCode, !string.IsNullOrEmpty(errorDetails) ? errorDetails : "Http response message error.");
            }

            if (httpResponseMessage.Content == null)
            {
                throw new ApiAiException(httpResponseMessage.StatusCode, "api.ai content returned is null.");
            }
        }

        #endregion

        #region Public Methods

        public static async Task<string> ToStringContentAsync(this HttpResponseMessage httpResponseMessage)
        {
            await ValidateResponse(httpResponseMessage);

            var content = await httpResponseMessage.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
            {
                throw new ApiAiException(HttpStatusCode.Conflict, "api.ai string content returned null or empty.");
            }

            return content;
        }

        public static async Task<Stream> ToStreamContentAsync(this HttpResponseMessage httpResponseMessage)
        {
            await ValidateResponse(httpResponseMessage);

            var content = await httpResponseMessage.Content.ReadAsStreamAsync();

            if (content == null || content.Length == 0)
            {
                throw new ApiAiException(HttpStatusCode.Conflict, "api.ai stream content returned null.");
            }

            return content;
        }

        #endregion
    }
}
