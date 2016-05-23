using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Ai.ApplicationService.Interfaces;

namespace Api.Ai.ApplicationService.Factories
{
    public class ApiAiAppServiceFactory : AbstractApiAiAppServiceFactory
    {
        #region Private Fields

        private readonly IServiceProvider _serviceProvider;

        #endregion

        #region Constructor

        public ApiAiAppServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion

        #region AbstractApiAiAppServiceFactory Members

        public override IQueryAppService CreateQueryAppService(string url, string apiKey)
        {
            var queryAppService = _serviceProvider.GetService(typeof(QueryAppService)) as IQueryAppService;

            if (queryAppService == null)
            {
                throw new Exception("ServiceProvider get 'IQueryAppService' service error.");
            }

            queryAppService.Initializer(url, apiKey);

            return queryAppService;

        }

        public override ITtsAppService CreateTtsAppService(string url, string apiKey)
        {
            var ttsAppService = _serviceProvider.GetService(typeof(TtsAppService)) as ITtsAppService;

            if (ttsAppService == null)
            {
                throw new Exception("ServiceProvider get 'ITtsAppService' service error.");
            }

            ttsAppService.Initializer(url, apiKey);

            return ttsAppService;

        }

        public override IEntitiesAppService CreateEntitiesAppService(string url, string apiKey)
        {
            var entitiesAppService = _serviceProvider.GetService(typeof(EntitiesAppService)) as IEntitiesAppService;

            if (entitiesAppService == null)
            {
                throw new Exception("ServiceProvider get 'IEntitiesAppService' service error.");
            }

            entitiesAppService.Initializer(url, apiKey);

            return entitiesAppService;

        }

        #endregion
    }
}
