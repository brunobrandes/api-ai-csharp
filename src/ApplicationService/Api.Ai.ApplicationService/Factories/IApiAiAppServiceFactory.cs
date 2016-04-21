using Api.Ai.ApplicationService.Interfaces;
using Api.Ai.Domain.DataTransferObject.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.ApplicationService.Factories
{
    public interface IApiAiAppServiceFactory
    {
        IQueryAppService CreateQueryAppService(string url, string apiKey);
        ITtsAppService CreateTtsAppService(string url, string apiKey);
    }
}
