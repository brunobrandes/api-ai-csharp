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

        public HttpClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #region IDispatcherFactory Members

        public IHttpClient Create(TimeSpan? timeout)
        {
            var result = _serviceProvider.GetService(typeof(ApiAiHttpClient)) as IHttpClient;

            if(result == null)
            {
                throw new Exception("Unexpected error get service provider ApiAiHttpClient");
            }

            if(timeout.HasValue)
            {
                result.Timeout = timeout.Value;
            }            

            return result;
        }

        #endregion

    }
}
