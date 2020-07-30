using System; 
using System.Net.Http; 
using Newtonsoft.Json;

namespace ApiTheMusicalKind.Backend.Services
{
    public abstract class BaseService
    { 
        public virtual int Count(string resourceUrl)
        {
            var s = Item(resourceUrl).Split(' ');
            return s.Length;
        }

        public string Item(string resourceUrl)
        {
            var baseAddress = new Uri("https://api.lyrics.ovh/v1/");

            using var httpClient = new HttpClient { BaseAddress = baseAddress };
            using var response = httpClient.GetAsync(resourceUrl);

            var responseData = response.Result.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Models.Lyric>(responseData.Result);

            return result.Lyrics;
        }
    }
}
