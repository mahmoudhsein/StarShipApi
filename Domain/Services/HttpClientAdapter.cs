using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class HttpClientAdapter : IHttpClientAdapter
    {
        public async Task<HttpResponse> Get(string address, Dictionary<string, string> headers, string acceptHeader)
        {
            using (var client = PrepareClient(address, headers, acceptHeader))
            {
                HttpResponseMessage httpResponse = await client.GetAsync(address);
                var data = await httpResponse.Content.ReadAsStringAsync();
                return new HttpResponse(data, (int)httpResponse.StatusCode);
            }
        }
        private HttpClient PrepareClient(string address, Dictionary<string, string> headers, string acceptHeader)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            Uri uri = new Uri(address);
            var client = new HttpClient(clientHandler) { BaseAddress = uri };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptHeader));
            foreach (var kvp in headers)
            {
                client.DefaultRequestHeaders.Add(kvp.Key, kvp.Value);
            }
            return client;
        }
    }
}
