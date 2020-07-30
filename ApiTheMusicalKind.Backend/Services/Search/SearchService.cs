using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ApiTheMusicalKind.Backend.Services.Search
{
    public class SearchService : BaseService, ISearchService
    {
        private readonly IConfiguration _config;

        public SearchService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Models.Search> Get(string resourceUrl)
        {
            const string baseUrl = "https://shazam.p.rapidapi.com/";
            const string host = "shazam.p.rapidapi.com";
            var key = _config["ShazamApi:Key"];

            var baseAddress = new Uri(baseUrl);

            using var httpClient = new HttpClient { BaseAddress = baseAddress };

            httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", host);
            httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", key);

            using var response = httpClient.GetAsync("search?locale=en-GB&offset=0&limit=5&term=" + resourceUrl);

            var responseData = await response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Models.Search>(responseData);

            foreach (var item in result.Tracks.Hits)
            {
                var artist = item.Track.Subtitle;
                var title = item.Track.Title;

                //TODO done quick fix for an issue where if the song name returned has a / the site bugs out, so for now encoding the /
                var newTitle = title.Contains("/") ? title.Replace("/", "%2F") : title;

                item.Track.LyricWordCount = Count($"{artist}/{newTitle}").Result;
            }

            return result;
        }
    }
}
