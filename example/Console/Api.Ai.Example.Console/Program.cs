using Api.Ai.ApplicationService.Factories;
using Api.Ai.Domain.DataTransferObject;
using Api.Ai.Domain.DataTransferObject.Request;
using Api.Ai.Domain.DataTransferObject.Response;
using Api.Ai.Domain.DataTransferObject.Serializer;
using Api.Ai.Domain.Service.Factories;
using Api.Ai.Infrastructure.Factories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Ai.Example.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            container.RegisterSingleton<IServiceProvider>(container);
            container.Register<IApiAiAppServiceFactory, ApiAiAppServiceFactory>();
            container.Register<IHttpClientFactory, HttpClientFactory>();

            //Get container api.ai app service factory 
            var apiAiAppServiceFactory = container.GetInstance<IApiAiAppServiceFactory>();

            Query(container, apiAiAppServiceFactory);
            //Tts(container, apiAiAppServiceFactory);
            //Entity(container, apiAiAppServiceFactory);
            //Context(container, apiAiAppServiceFactory);

            System.Console.ReadLine();
        }

        #region Private Methods

        private static void Query(Container container, IApiAiAppServiceFactory apiAiAppServiceFactory)
        {
            ///Create full contact app service  
            var queryAppService = apiAiAppServiceFactory.CreateQueryAppService("https://api.api.ai/v1", "YOUR_ACCESS_TOKEN");

            ///Create query request
            var queryRequest = new QueryRequest
            {
                SessionId = "1",
                Query = new string[] { "Hello, I want a pizza" },
                Lang = Domain.Enum.Language.English
            };

            /// Call api.ai query by get 
            var queryResponse = queryAppService.PostQueryAsync(queryRequest).Result;

            System.Console.Write(ApiAiJson<QueryResponse>.Serialize(queryResponse));
        }

        private static void Tts(Container container, IApiAiAppServiceFactory apiAiAppServiceFactory)
        {
            ///Create full contact app service  
            var ttsAppService = apiAiAppServiceFactory.CreateTtsAppService("https://api.api.ai/v1", "YOUR_ACCESS_TOKEN");

            ///Create query request
            var ttsRequest = new TtsRequest
            {
                Text = "Hello, I want a pizza"
            };

            /// First - Create a path
            string path = @"D:\api-ai-csharp\tts";

            /// Call api.ai query by get 
            var ttsResponse = ttsAppService.GetTtsAsync(ttsRequest).Result;

            if (ttsResponse == null)
            {
                throw new Exception("tts error - Get tts async returned null");
            }

            var fileName = ttsResponse.WriteToFile(path).Result;

            System.Console.Write($"File created: {path}\\{fileName}");
        }

        private static void Entity(Container container, IApiAiAppServiceFactory apiAiAppServiceFactory)
        {
            var entityAppService = apiAiAppServiceFactory.CreateEntitiesAppService("https://api.api.ai/v1", "YOUR_ACCESS_TOKEN");

            var entities = entityAppService.GetAllAsync().Result;

            if (entities != null)
            {
                System.Console.Write($"{entities.Count} entities found.");

                var entity = entityAppService.GetByIdAsync(entities.FirstOrDefault().Id).Result;
            }

            try
            {
                var newEntity = new Entity { Name = "test", Entries = new List<Entry> { { new Entry { Value = "test", Synonyms = new List<string> { "test" } } } } };

                newEntity.Id = entityAppService.CreateAsync(new Entity { Name = "test", Entries = new List<Entry> { { new Entry { Value = "test", Synonyms = new List<string> { "test" } } } } }).Result;

                if (!string.IsNullOrEmpty(newEntity.Id))
                {
                    entityAppService.AddEntriesSpecifiedEntityAsync(newEntity.Id, new List<Entry> { { new Entry { Value = "test-2", Synonyms = new List<string> { "a", "b" } } } }).Wait();

                    entityAppService.UpdatesEntityEntriesAsync(newEntity.Id, new List<Entry> { { new Entry { Value = "test-2", Synonyms = new List<string> { "c", "d" } } } }).Wait();

                    newEntity.Name = "test-up";

                    entityAppService.UpdateAsync(newEntity).Wait();

                    entityAppService.DeleteAsync(newEntity.Id).Wait();
                }
            }
            catch (Exception ex)
            {
                System.Console.Write($"Error - {ex.ToString()}");
            }
        }

        private static void Context(Container container, IApiAiAppServiceFactory apiAiAppServiceFactory)
        {
            var contextAppService = apiAiAppServiceFactory.CreateContextAppService("https://api.api.ai/v1", "YOUR_ACCESS_TOKEN");
            
            try
            {
                contextAppService.DeleteAsync("11").Wait();
            }
            catch (Exception ex)
            {
                System.Console.Write($"Error - {ex.ToString()}");
            }
        }

        #endregion
    }
}
