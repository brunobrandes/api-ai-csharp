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
            var apiAiAppService = _serviceProvider.GetService(typeof(QueryAppService)) as IQueryAppService;

            if (apiAiAppService == null)
            {
                throw new Exception("ServiceProvider get 'IApiAiAppService<T>' service error.");
            }

            apiAiAppService.Initializer(url, apiKey);

            return apiAiAppService;

        }

        #endregion
    }
}
