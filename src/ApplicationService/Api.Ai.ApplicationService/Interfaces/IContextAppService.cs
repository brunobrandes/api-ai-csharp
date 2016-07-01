using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.ApplicationService.Interfaces
{
    public interface IContextAppService : IApiAiAppService
    {
        Task DeleteAsync(string sessionId);
    }
}
