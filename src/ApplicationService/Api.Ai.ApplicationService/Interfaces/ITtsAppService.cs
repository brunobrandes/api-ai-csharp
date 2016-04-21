using Api.Ai.Domain.DataTransferObject.Request;
using Api.Ai.Domain.DataTransferObject.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.ApplicationService.Interfaces
{
    public interface ITtsAppService : IApiAiAppService<TtsResponse>
    {
        Task<TtsResponse> GetTtsAsync(TtsRequest request);
    }
}
