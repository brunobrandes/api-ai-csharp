using Api.Ai.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Infrastructure.Http
{
    public class ApiAiHttpClient : IHttpClient
    {
        #region Private Fields

        private readonly HttpClient _httpClient;

        #endregion

        #region Constructor

        public ApiAiHttpClient(IServiceProvider serviceProvider)
        {
            _httpClient = new HttpClient();
        }

        #endregion

        #region IHttpClient Members

        public HttpRequestHeaders DefaultRequestHeaders
        {
            get
            {
                return _httpClient.DefaultRequestHeaders;
            }
        }

        public TimeSpan Timeout
        {
            get
            {
                return _httpClient.Timeout;
            }
            set
            {
                _httpClient.Timeout = value;
            }
        }

        public Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            var httpResponseMessage = _httpClient.GetAsync(uri);

            if (httpResponseMessage == null)
            {
                throw new Exception("Get async error - Http response message is null.");
            }

            return httpResponseMessage;
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            var httpResponseMessage = _httpClient.PostAsync(requestUri, content);

            if (httpResponseMessage == null)
            {
                throw new Exception("Post async error - Http response message is null.");
            }

            return httpResponseMessage;
        }

        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            var httpResponseMessage = _httpClient.PutAsync(requestUri.AbsoluteUri, content);

            if (httpResponseMessage == null)
            {
                throw new Exception("Put async error - Http response message is null.");
            }

            return httpResponseMessage;
        }

        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
        {
            var httpResponseMessage = _httpClient.DeleteAsync(requestUri);

            if (httpResponseMessage == null)
            {
                throw new Exception("Delete async error - Http response message is null.");
            }

            return httpResponseMessage;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        #endregion
    }
}
