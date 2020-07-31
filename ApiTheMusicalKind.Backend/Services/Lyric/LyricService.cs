using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
    }
}
