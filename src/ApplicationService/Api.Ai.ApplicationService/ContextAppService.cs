using Api.Ai.ApplicationService.Interfaces;
using Api.Ai.Domain.Service.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Ai.ApplicationService.Extensions;
using Api.Ai.Domain.Service.Serializer;
using Api.Ai.Domain.DataTransferObject.Response;

namespace Api.Ai.ApplicationService
{
    public class ContextAppService : ApiAiAppService, IContextAppService
    {
        #region Contructor

        public ContextAppService(IServiceProvider serviceProvider, IHttpClientFactory httpClientFactory)
                : base(serviceProvider, httpClientFactory)
        {
        }

        #endregion

        #region IContextAppService

        public async Task DeleteAsync(string sessionId)
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

                var uri = new Uri($"{BaseUrl}/contexts?{sessionId}");                

                var httpResponseMessage = await httpClient.GetAsync(uri);

                var content = await httpResponseMessage.ToStringContentAsync();

                var responseBase = ApiAiJson<ResponseBase>.Deserialize(content);

                if (responseBase == null)
                {
                    throw new Exception("Delete contexts error - Deserialize content is null or empty.");
                }

                if (responseBase.Status.IsSuccessStatusCode)
                {
                    throw new Exception($"Delete contexts error - Invalid http status code '{responseBase.Status.Code}'");
                }

            }
        }

        #endregion
    }
}
