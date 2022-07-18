using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IHttpClientAdapter
    {
        Task<HttpResponse> Get(string address, Dictionary<string, string> headers, string acceptHeader);
    }
}
