using Api.Ai.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Ai.Domain.DataTransferObject.Request;
using Api.Ai.Domain.DataTransferObject.Response;
using Api.Ai.Domain.Service.Interfaces;
using Api.Ai.Domain.Service.Factories;
using Api.Ai.Infrastructure.Json;
using System.Net.Http;
using System.Net;
using Api.Ai.Domain.DataTransferObject.Extensions;

namespace Api.Ai.ApplicationService
{
    public class QueryAppService : ApiAiAppService, IQueryAppService
    {
        #region Contructor

        public QueryAppService(IServiceProvider serviceProvider, IHttpClientFactory httpClientFactory)
                : base(serviceProvider, httpClientFactory)
        {
        }

        #endregion
        
        #region IQueryAppService Members

        public async Task<QueryResponse> GetQueryAsync(QueryRequest request)
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                var httpResponseMessage = await httpClient.GetAsync(new Uri($"{BaseUrl}/{request.ToQueryString()}"));

                if(httpResponseMessage != null)
                {
                    var content = await httpResponseMessage.ToStringContentAsync();
                    return ApiAiJson<QueryResponse>.Deserialize(content);
                }
                else
                {
                    throw new Exception("Unexpected error GetQueryAsync - httpResponseMessage is null.");
                }               
            }
        }

        public async Task<QueryResponse> PostQueryAsync(QueryRequest request)
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                var httpResponseMessage = await httpClient.PostAsync(new HttpRequestMessage
                {
                    RequestUri = new Uri($"{BaseUrl}/query?v={request.V}"),
                    Content = new StringContent(ApiAiJson<QueryRequest>.Serialize(request), Encoding.UTF8, "application/json")
                });

                if (httpResponseMessage != null)
                {
                    var content = await httpResponseMessage.ToStringContentAsync();
                    return ApiAiJson<QueryResponse>.Deserialize(content);
                }
                else
                {
                    throw new Exception("Unexpected error GetQueryAsync - httpResponseMessage is null.");
                }
            }
        }

        #endregion
    }
}
