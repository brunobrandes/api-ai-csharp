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

        private static void ValidateResponse(HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = httpResponseMessage.StatusCode
                });
            }

            if (httpResponseMessage.Content == null)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent,
                    Content = new StringContent("api.ai conent returned is null.")
                });
            }
        }

        #endregion

        #region Public Methods

        public static async Task<string> ToStringContentAsync(this HttpResponseMessage httpResponseMessage)
        {
            ValidateResponse(httpResponseMessage);

            var content = await httpResponseMessage.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent,
                    Content = new StringContent("api.ai string conent returned null or empty.")
                });
            }

            return content;
        }

        public static async Task<Stream> ToStreamContentAsync(this HttpResponseMessage httpResponseMessage)
        {
            ValidateResponse(httpResponseMessage);

            var content = await httpResponseMessage.Content.ReadAsStreamAsync();

            if (content == null || content.Length == 0)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent,
                    Content = new StringContent("api.ai stream conent returned null.")
                });
            }

            return content;
        }

        #endregion
    }
}
