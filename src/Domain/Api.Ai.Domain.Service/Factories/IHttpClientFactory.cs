using Api.Ai.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Ai.Domain.Service.Factories
{
    public interface IHttpClientFactory
    {
        IHttpClient Create();

        IHttpClient Create(string accessToken);

        IHttpClient Create(TimeSpan timeout, string accessToken);
    }
}
