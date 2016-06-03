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
using System.Net.Http;
using System.Net;
using Api.Ai.Domain.DataTransferObject.Extensions;
using Api.Ai.Domain.Service.Serializer;
using Api.Ai.ApplicationService.Extensions;

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
                var uri = new Uri($"{BaseUrl}/{request.ToHttpGetQueryString()}");

                var httpResponseMessage = await httpClient.GetAsync(uri);

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

        public async Task<QueryResponse> PostQueryAsync(QueryRequest request)
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                var uri = new Uri($"{BaseUrl}/{request.ToHttpPostQueryString()}");

                var queryRequestJson = ApiAiJson<QueryRequest>.Serialize(request);

                var httpResponseMessage = await httpClient.PostAsync(uri, new StringContent(queryRequestJson, Encoding.UTF8, "application/json"));

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
