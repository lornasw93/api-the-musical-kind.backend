using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ApiTheMusicalKind.Backend.Services.Search
{
    public class SearchService : ISearchService
    {
        private readonly IConfiguration _config;

        public SearchService(IConfiguration config)
        {
            _config = config;
        }

        public Models.Search Get(string resourceUrl)
        { 
            var baseUrl = _config["ShazamApi:BaseUrl"];
            var host = _config["ShazamApi:Host"]; 
            var key = _config["ShazamApi:Key"]; 

            var baseAddress = new Uri(baseUrl);

            using var httpClient = new HttpClient { BaseAddress = baseAddress };

            httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", host);
            httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", key);

            using var response = httpClient.GetAsync("search?locale=en-GB&offset=0&limit=500&term=" + resourceUrl);

            var responseData = response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Models.Search>(responseData.Result);

            return result;
        }
    }
}
