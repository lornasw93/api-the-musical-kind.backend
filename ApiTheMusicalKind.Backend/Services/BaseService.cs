using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApiTheMusicalKind.Backend.Models;
using Newtonsoft.Json;

namespace ApiTheMusicalKind.Backend.Services
{
    public interface IBaseService
    {
        string Item(string resourceUrl);
    }

    public class BaseService : IBaseService
    {
        //private readonly IHttpClientFactory _clientFactory;

        //private const string HttpClientName = "lyricsHttpClient";

        //public BaseService(IHttpClientFactory clientFactory)
        //{
        //    _clientFactory = clientFactory;
        //}

        //private async Task<string> GetResponse(string resourceUrl)
        //{
        //    var client = _clientFactory.CreateClient(HttpClientName);
        //    var response = client.GetAsync(resourceUrl).Result;

        //    response.EnsureSuccessStatusCode();

        //    return await response.Content.ReadAsStringAsync();
        //}

        public string Item(string resourceUrl)
        {
            var baseAddress = new Uri("https://api.lyrics.ovh/v1/");

            using var httpClient = new HttpClient { BaseAddress = baseAddress };
            using var response = httpClient.GetAsync("Coldplay/Yellow");

            var responseData = response.Result.Content.ReadAsStringAsync();

            var s = JsonConvert.DeserializeObject<Lyric>(responseData.Result);

            return s.Lyrics;
        }
    }
}
