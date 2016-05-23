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
            return _httpClient.GetAsync(uri);
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            return _httpClient.PostAsync(requestUri, content);
        }

        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            return _httpClient.PutAsync(requestUri.AbsoluteUri, content);
        }

        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
        {
            return _httpClient.DeleteAsync(requestUri);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        #endregion
    }
}
