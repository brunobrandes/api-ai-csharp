using Api.Ai.ApplicationService.Interfaces;
using Api.Ai.Domain.DataTransferObject.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.ApplicationService.Factories
{
    public abstract class AbstractApiAiAppServiceFactory : IApiAiAppServiceFactory
    {
        #region IFullContactAppServiceFactory

        public abstract IQueryAppService CreateQueryAppService(string url, string apiKey);
        public abstract ITtsAppService CreateTtsAppService(string url, string apiKey);
        public abstract IEntitiesAppService CreateEntitiesAppService(string url, string apiKey);
        public abstract IContextAppService CreateContextAppService(string url, string apiKey);

        #endregion
    }
}
