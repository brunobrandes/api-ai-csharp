using Api.Ai.ApplicationService.Interfaces;
using Api.Ai.Domain.DataTransferObject.Extensions;
using Api.Ai.Domain.DataTransferObject.Request;
using Api.Ai.Domain.DataTransferObject.Response;
using Api.Ai.Domain.Service.Factories;
using Api.Ai.Infrastructure.Json;
using System;
using System.Threading.Tasks;

namespace Api.Ai.ApplicationService
{
    public class TtsAppService : ApiAiAppService, ITtsAppService
    {
        #region Contructor

        public TtsAppService(IServiceProvider serviceProvider, IHttpClientFactory httpClientFactory)
                : base(serviceProvider, httpClientFactory)
        {
        }

        #endregion

        #region ITtsAppService members

        public async Task<TtsResponse> GetTtsAsync(TtsRequest request)
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US");

                var httpResponseMessage = await httpClient.GetAsync(new Uri($"{BaseUrl}/{request.ToQueryString()}"));

                if (httpResponseMessage != null)
                {
                    var content = await httpResponseMessage.ToStreamContentAsync();
                    return new TtsResponse(content);
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
