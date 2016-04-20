using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.Service.Interfaces
{
    public interface IHttpClient : IDisposable
    {
        HttpRequestHeaders DefaultRequestHeaders { get; }

        TimeSpan Timeout { get; set; }

        Task<HttpResponseMessage> GetAsync(Uri url);

        Task<HttpResponseMessage> PostAsync(HttpRequestMessage requestMessage);
    }
}
