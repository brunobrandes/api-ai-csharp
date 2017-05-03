using Api.Ai.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Ai.Domain.DataTransferObject;
using Api.Ai.Domain.DataTransferObject.Response;
using Api.Ai.Domain.Service.Factories;
using Api.Ai.Domain.DataTransferObject.Extensions;
using Api.Ai.Domain.Enum;
using System.Net.Http;
using Api.Ai.ApplicationService.Extensions;
using Api.Ai.Domain.DataTransferObject.Serializer;
using Api.Ai.Domain.Service.Exceptions;
using System.Net;

namespace Api.Ai.ApplicationService
{
    public class EntitiesAppService : ApiAiAppService, IEntitiesAppService
    {
        #region Contructor

        public EntitiesAppService(IServiceProvider serviceProvider, IHttpClientFactory httpClientFactory)
                : base(serviceProvider, httpClientFactory)
        {
        }

        #endregion

        #region IEntitiesAppService Members

        public async Task<List<EntityResponse>> GetAllAsync()
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                var httpResponseMessage = await httpClient.GetAsync(new Uri($"{BaseUrl}/entities"));

                var content = await httpResponseMessage.ToStringContentAsync();
                return ApiAiJson<List<EntityResponse>>.Deserialize(content);

            }
        }

        public async Task<Entity> GetByIdAsync(string id)
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                var httpResponseMessage = await httpClient.GetAsync(new Uri($"{BaseUrl}/entities/{id}?v={ApiAiVersion.Default}"));

                var content = await httpResponseMessage.ToStringContentAsync();
                return ApiAiJson<Entity>.Deserialize(content);
            }
        }

        public async Task<string> CreateAsync(Entity entity)
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                var httpResponseMessage = await httpClient.PostAsync(new Uri($"{BaseUrl}/entities?v={ApiAiVersion.Default}"),
                    new StringContent(ApiAiJson<Entity>.Serialize(entity), Encoding.UTF8, "application/json"));

                var content = await httpResponseMessage.ToStringContentAsync();
                var responseBase = ApiAiJson<ResponseBase>.Deserialize(content);

                if (responseBase == null)
                {
                    throw new ApiAiException(HttpStatusCode.Conflict, "Create entity error - Deserialize content is null or empty.");
                }

                if (!responseBase.Status.IsSuccessStatusCode)
                {
                    throw new ApiAiException(responseBase.Status.Code, "Create entity error.");
                }

                return responseBase.Id;
            }
        }

        public async Task UpdateAsync(Entity entity)
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                var httpResponseMessage = await httpClient.PutAsync(new Uri($"{BaseUrl}/entities/{entity.Id}"),
                    new StringContent(ApiAiJson<Entity>.Serialize(entity), Encoding.UTF8, "application/json"));

                var content = await httpResponseMessage.ToStringContentAsync();
                var responseBase = ApiAiJson<ResponseBase>.Deserialize(content);

                if (responseBase == null)
                {
                    throw new ApiAiException(HttpStatusCode.Conflict, "Update entity error - Deserialize content is null or empty.");
                }

                if (!responseBase.Status.IsSuccessStatusCode)
                {
                    throw new ApiAiException(responseBase.Status.Code, "Update entity error.");
                }
            }
        }

        public async Task DeleteAsync(string id)
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                var httpResponseMessage = await httpClient.DeleteAsync(new Uri($"{BaseUrl}/entities/{id}?v={ApiAiVersion.Default}"));

                var content = await httpResponseMessage.ToStringContentAsync();
                var responseBase = ApiAiJson<ResponseBase>.Deserialize(content);

                if (responseBase == null)
                {
                    throw new ApiAiException(HttpStatusCode.Conflict, "Delete entity error - Deserialize content is null or empty.");
                }

                if (!responseBase.Status.IsSuccessStatusCode)
                {
                    throw new ApiAiException(responseBase.Status.Code, "Delete entity error.");
                }
            }
        }

        public async Task AddEntriesSpecifiedEntityAsync(string id, List<Entry> entries)
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                var httpResponseMessage = await httpClient.PostAsync(new Uri($"{BaseUrl}/entities/{id}/entries"),
                    new StringContent(ApiAiJson<List<Entry>>.Serialize(entries), Encoding.UTF8, "application/json"));

                var content = await httpResponseMessage.ToStringContentAsync();
                var responseBase = ApiAiJson<ResponseBase>.Deserialize(content);

                if (responseBase == null)
                {
                    throw new ApiAiException(HttpStatusCode.Conflict, "Add entries specified entity error - Deserialize content is null or empty.");
                }

                if (!responseBase.Status.IsSuccessStatusCode)
                {
                    throw new ApiAiException(responseBase.Status.Code, "Add entries specified entity error.");
                }
            }
        }

        public async Task UpdatesEntityEntriesAsync(string id, List<Entry> entries)
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                var httpResponseMessage = await httpClient.PutAsync(new Uri($"{BaseUrl}/entities/{id}/entries"),
                    new StringContent(ApiAiJson<List<Entry>>.Serialize(entries), Encoding.UTF8, "application/json"));

                var content = await httpResponseMessage.ToStringContentAsync();
                var responseBase = ApiAiJson<ResponseBase>.Deserialize(content);

                if (responseBase == null)
                {
                    throw new ApiAiException(HttpStatusCode.Conflict, "Updates entity entries error - Deserialize content is null or empty.");
                }

                if (!responseBase.Status.IsSuccessStatusCode)
                {
                    throw new ApiAiException(responseBase.Status.Code, "Updates entity entries error.");
                }
            }
        }

        #endregion
    }
}
