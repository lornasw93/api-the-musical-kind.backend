using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ApiTheMusicalKind.Backend.Models;

namespace ApiTheMusicalKind.Backend.Services.Lyric
{
    public class LyricService : BaseService, ILyricService
    {
        public string Get(string resourceUrl)
        {
            return Item(resourceUrl);
        }

        public int GetCount(string resourceUrl)
        {
            return Count(resourceUrl);
        }

        public CustomLyric GetCustom(string resourceUrl)
        {
            var lyric = Item(resourceUrl);

            return new CustomLyric()
            {
                Lyrics = lyric,
                Common = GetCommon(lyric)
            };
        }

        private static IEnumerable<IGrouping<string, string>> GetCommon(string lyric)
        {
            return Regex.Split(lyric.ToLower(), @"\W+")
                .Where(s => s.Length > 3)
                .GroupBy(s => s)
                .OrderByDescending(g => g.Count())
                .Take(5);
        }

        //private static string Item(string resourceUrl)
        //{
        //    var baseAddress = new Uri("https://api.lyrics.ovh/v1/");

        //    using var httpClient = new HttpClient { BaseAddress = baseAddress };
        //    using var response = httpClient.GetAsync(resourceUrl);

        //    var responseData = response.Result.Content.ReadAsStringAsync();

        //    var result = JsonConvert.DeserializeObject<Models.Lyric>(responseData.Result);

        //    return result.Lyrics;
        //}
    }
}
