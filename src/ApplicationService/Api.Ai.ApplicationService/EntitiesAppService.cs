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
using Api.Ai.Domain.Service.Serializer;
using Api.Ai.ApplicationService.Extensions;

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
                    throw new Exception("Create entity error - Deserialize content is null or empty.");
                }

                if (responseBase.Status.IsSuccessStatusCode)
                {
                    throw new Exception($"Create entity error - Invalid http status code '{responseBase.Status.Code}'");
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
                    throw new Exception("Update entity error - Deserialize content is null or empty.");
                }

                if (responseBase.Status.IsSuccessStatusCode)
                {
                    throw new Exception($"Update entity error - Invalid http status code '{responseBase.Status.Code}'");
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
                    throw new Exception("Delete entity error - Deserialize content is null or empty.");
                }

                if (responseBase.Status.IsSuccessStatusCode)
                {
                    throw new Exception($"Delete entity error - Invalid http status code '{responseBase.Status.Code}'");
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
                    throw new Exception("Add entries specified entity error - Deserialize content is null or empty.");
                }

                if (responseBase.Status.IsSuccessStatusCode)
                {
                    throw new Exception($"Add entries specified entity error  - Invalid http status code '{responseBase.Status.Code}'");
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
                    throw new Exception("Updates entity entries error - Deserialize content is null or empty.");
                }

                if (responseBase.Status.IsSuccessStatusCode)
                {
                    throw new Exception($"Updates entity entries error - Invalid http status code '{responseBase.Status.Code}'");
                }
            }
        }

        #endregion
    }
}
