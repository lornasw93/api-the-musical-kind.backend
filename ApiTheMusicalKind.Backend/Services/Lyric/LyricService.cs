using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApiTheMusicalKind.Backend.Models;
using Newtonsoft.Json;

namespace ApiTheMusicalKind.Backend.Services.Lyric
{
    public class LyricService : ILyricService
    {
        public async Task<object> GetLyrics(string resourceUrl)
        {
            var baseAddress = new Uri(BaseUrlConstant.LyricsOvh);

            using var httpClient = new HttpClient { BaseAddress = baseAddress };
            using var response = httpClient.GetAsync(resourceUrl);
             
            var responseData = await response.Result.Content.ReadAsStringAsync();
             
            //TODO better
            if (responseData.Contains("No lyrics found"))
                return null;

            var result = JsonConvert.DeserializeObject<Models.Lyric>(responseData);
            var count = result.Lyrics.Split(' ').Length;

            return new LyricsRootObject
            {
                Lyrics = result.Lyrics,
                WordCount = count,
                Common = GetCommon(result.Lyrics)
            }; 
        }

        private IEnumerable<IGrouping<string, string>> GetCommon(string lyric)
        {
            return Regex.Split(lyric.ToLower(), @"\W+")
                .Where(s => s.Length > 3)
                .GroupBy(s => s)
                .OrderByDescending(g => g.Count())
                .Take(5);
        }
    }
}