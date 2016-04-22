using Api.Ai.ApplicationService.Factories;
using Api.Ai.Domain.DataTransferObject.Request;
using Api.Ai.Domain.DataTransferObject.Response;
using Api.Ai.Domain.Service.Factories;
using Api.Ai.Infrastructure.Factories;
using Api.Ai.Infrastructure.Json;
using SimpleInjector;
using System;

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

            //Query(container, apiAiAppServiceFactory);
            Tts(container, apiAiAppServiceFactory);

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
                Query = new string[] { "Hello, I want a pizza" },
                Lang = Domain.Enum.Language.English
            };

            /// Call api.ai query by get 
            var queryResponse = queryAppService.GetQueryAsync(queryRequest).Result;

            System.Console.Write(ApiAiJson<QueryResponse>.Serialize(queryResponse));
        }

        private static void Tts(Container container,IApiAiAppServiceFactory apiAiAppServiceFactory)
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

            if(ttsResponse == null)
            {
                throw new Exception("tts error - Get tts async returned null");
            }

            var fileName =  ttsResponse.WriteToFile(path).Result;

            System.Console.Write($"File created: {path}\\{fileName}");
        }

        #endregion
    }
}
