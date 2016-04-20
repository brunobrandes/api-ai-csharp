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

            ///Get container api.ai app service factory 
            var apiAiAppServiceFactory = container.GetInstance<IApiAiAppServiceFactory>();

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

            System.Console.ReadLine();
        }
    }
}
