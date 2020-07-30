using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiTheMusicalKind.Backend.Services
{
    public abstract class BaseService
    {
        public virtual async Task<int> Count(string resourceUrl)
        {
            var item = await Item(resourceUrl);
            var itemResult = JsonConvert.DeserializeObject(item)?.ToString();
            
            return !string.IsNullOrWhiteSpace(itemResult) ? item.Split(' ').Length : 0;
        }

        public async Task<string> Item(string resourceUrl)
        {
            var baseAddress = new Uri("https://api.lyrics.ovh/v1/");

            using var httpClient = new HttpClient { BaseAddress = baseAddress };
            using var response = httpClient.GetAsync(resourceUrl);

            var responseData = await response.Result.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Models.Lyric>(responseData);

            return result.Lyrics;
        }
    }
}
