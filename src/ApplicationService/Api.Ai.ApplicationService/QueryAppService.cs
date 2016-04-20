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
using Api.Ai.Domain.DataTransferObject.Extensions;
using Api.Ai.Infrastructure.Json;
using System.Net.Http;
using System.Web.Http;
using System.Net;

namespace Api.Ai.ApplicationService
{
    public class QueryAppService : ApiAiAppService<QueryResponse>, IQueryAppService
    {
        #region Contructor

        public QueryAppService(IServiceProvider serviceProvider, IHttpClientFactory httpClientFactory)
                : base(serviceProvider, httpClientFactory)
        {
        }

        #endregion

        #region Private Methods

        private async Task<string> GetContentResponse(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage == null)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent("api.ai invalid response. httpResponseMessage is null or empty.")
                });
            }

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

            var content = await httpResponseMessage.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content))
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent,
                    Content = new StringContent("api.ai string conent returned is null or empty.")
                });
            }

            return content;
        }

        #endregion

        #region IQueryAppService Members

        public async Task<QueryResponse> GetQueryAsync(QueryRequest request)
        {
            using (var httpClient = HttpClientFactory.Create(TimeSpan.FromSeconds(45)))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

                var httpResponseMessage = await httpClient.GetAsync(new Uri($"{BaseUrl}/{request.ToQueryString()}"));

                var content = await GetContentResponse(httpResponseMessage);

                return ApiAiJson<QueryResponse>.Deserialize(content);
            }
        }

        public async Task<QueryResponse> PostQueryAsync(QueryRequest request)
        {
            using (var httpClient = HttpClientFactory.Create(TimeSpan.FromSeconds(45)))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

                var httpResponseMessage = await httpClient.PostAsync(new HttpRequestMessage
                {
                    RequestUri = new Uri($"{BaseUrl}/query?v={request.V}"),
                    Content = new StringContent(ApiAiJson<QueryRequest>.Serialize(request), Encoding.UTF8, "application/json")
                });

                var content = await GetContentResponse(httpResponseMessage);

                return ApiAiJson<QueryResponse>.Deserialize(content);
            }
        }

        #endregion

    }
}
