using Domain.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class StartShipService : IStartShipService
    {
        private IHttpClientAdapter _httpClientAdapter;
        private IConfiguration _configuration;
        private string ServiceUrl
        {
            get
            {
                return _configuration.GetValue<string>(Constants.BASE_URL);
            }
        }
        public StartShipService(IConfiguration configuration,IHttpClientAdapter httpClientAdapter)
        {
           _configuration=configuration;
            _httpClientAdapter = httpClientAdapter;
        }
        public async Task<IEnumerable<BasicStarShipModel>> GetStarShipInfo(int? page , int? limit)
        {
            var headers = new Dictionary<string, string>{};
            string endpoint = ServiceUrl + "starships";
            var response=await _httpClientAdapter.Get($"{endpoint}", headers, "application/json");
            if (response.Code == (int)HttpStatusCode.OK)
            {
                var info = JsonConvert.DeserializeObject<StarShipListingsGetResponseModel>(response.Message);
                return info.Results;
            }
            else
            {
                return null;
            }
           
        }

        public async Task<StarShipModel> GetStarShipInfoById(string id)
        {
            var headers = new Dictionary<string, string> { };
            string endpoint = ServiceUrl + "starships/"+id;
            var response = await _httpClientAdapter.Get($"{endpoint}", headers, "application/json");
            if (response.Code == (int)HttpStatusCode.OK)
            {
                var info = JsonConvert.DeserializeObject<StarShipGetResponseModel>(response.Message);
                return info.Result;
            }
            else
            {
                return null;
            }
        }
    }
}
