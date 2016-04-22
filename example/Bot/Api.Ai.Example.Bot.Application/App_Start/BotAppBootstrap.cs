using Api.Ai.ApplicationService.Factories;
using Api.Ai.Domain.Service.Factories;
using Api.Ai.Infrastructure.Factories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api.Ai.Example.Bot.Application
{
    public class BotAppBootstrap
    {
        public static Container RegisterContainer(HttpConfiguration config)
        {
            var container = new Container();

            container.RegisterWebApiControllers(config);
            
            container.RegisterSingleton<IServiceProvider>(container);

            container.RegisterSingleton<IApiAiAppServiceFactory, ApiAiAppServiceFactory>();
            container.RegisterSingleton<IHttpClientFactory, HttpClientFactory>();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            return container;
        }
    }
}