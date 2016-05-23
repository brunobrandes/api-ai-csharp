using Api.Ai.ApplicationService.Interfaces;
using Api.Ai.Domain.Service.Factories;
using Api.Ai.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.ApplicationService
{
    public class ApiAiAppService : IApiAiAppService
    {
        #region Private Fields

        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpClientFactory _htpClientFactory;

        private string _baseUrl;
        private string _accessToken;
        

        #endregion

        #region Constructor

        public ApiAiAppService(IServiceProvider serviceProvider, IHttpClientFactory htpClientFactory)
        {
            _serviceProvider = serviceProvider;
            _htpClientFactory = htpClientFactory;
        }

        #endregion

        #region IApiAiAppService

        public IHttpClientFactory HttpClientFactory
        {
            get
            {
                return _htpClientFactory;
            }
        }
        
        public string BaseUrl
        {
            get
            {
                return _baseUrl;
            }
        }

        public string AccessToken
        {
            get
            {
                return _accessToken;
            }
        }
               

        public void Initializer(string baseUrl, string accessToken)
        {
            _baseUrl = baseUrl;
            _accessToken = accessToken;
        }

        #endregion
    }
}
