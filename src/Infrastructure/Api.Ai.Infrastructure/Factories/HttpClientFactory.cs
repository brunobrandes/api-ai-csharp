using Api.Ai.Domain.Service.Factories;
using Api.Ai.Domain.Service.Interfaces;
using Api.Ai.Infrastructure.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Infrastructure.Factories
{
    public class HttpClientFactory : IHttpClientFactory
    {
        #region Private Fields

        private readonly IServiceProvider _serviceProvider;

        #endregion

        #region Contructor

        public HttpClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion

        #region IDispatcherFactory Members

        /// <summary>
        /// Create with default timeout 60s
        /// </summary>
        /// <returns></returns>
        public IHttpClient Create()
        {
            return Create(TimeSpan.FromSeconds(60), string.Empty);
        }

        public IHttpClient Create(string accessToken)
        {
            return Create(TimeSpan.FromSeconds(60), accessToken);
        }

        public IHttpClient Create(TimeSpan timeout, string accessToken)
        {
            var result = _serviceProvider.GetService(typeof(ApiAiHttpClient)) as IHttpClient;

            if (result == null)
            {
                throw new Exception("Unexpected error get service provider ApiAiHttpClient");
            }

            if (!string.IsNullOrEmpty(accessToken))
            {
                result.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            }

            result.Timeout = timeout;

            return result;
        }

        #endregion

    }
}
