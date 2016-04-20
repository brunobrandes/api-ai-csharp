using Api.Ai.Domain.DataTransferObject.Response;
using Api.Ai.Domain.Service.Factories;
using Api.Ai.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.ApplicationService.Interfaces
{
    public interface IApiAiAppService<T> where T : class
    {
        IHttpClientFactory HttpClientFactory { get; }
        
        /// <summary>
        /// Base Url
        /// </summary>
        string BaseUrl { get; }

        /// <summary>
        /// access token
        /// </summary>
        string AccessToken { get; }

        void Initializer(string baseUrl, string accessToken);
    }
}
