using Api.Ai.Domain.DataTransferObject.Request;
using Api.Ai.Domain.DataTransferObject.Response;
using Api.Ai.Domain.Service.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.ApplicationService.Interfaces
{
    public interface IQueryAppService : IApiAiAppService<QueryResponse>
    {
        Task<QueryResponse> GetQueryAsync(QueryRequest request);

        Task<QueryResponse> PostQueryAsync(QueryRequest request);
    }
}
