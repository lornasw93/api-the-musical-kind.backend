using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApiTheMusicalKind.Backend.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ApiTheMusicalKind.Backend.Services.Search
{
    public class DeezerService : IDeezerService
    {
        private readonly IConfiguration _config;

        public DeezerService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Deezer> GetSearchResults(string query)
        {
            var key = _config["RapidApi:Key"];

            var baseAddress = new Uri(BaseUrlConstant.DeezerApi);

            using var httpClient = new HttpClient { BaseAddress = baseAddress };

            httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", HostConstant.DeezerApi);
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", key);

            //TODO done quick fix for an issue where if the song name returned has a / the site bugs out, so for now encoding the /
            var newQuery = query.Contains("/") ? query.Replace("/", "%2F") : query;

            using var response = httpClient.GetAsync("search?q=" + query);

            var responseData = await response.Result.Content.ReadAsStringAsync();

            var result1 = JsonConvert.DeserializeObject<InitialData>(responseData);

            //TODO better
            if (result1.data.Length == 0)
                return null;

            var result = JsonConvert.DeserializeObject<Deezer>(responseData);

            return result;
        }
    }
}
