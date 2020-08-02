using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ApiTheMusicalKind.Backend.Models
{
    public class Lyric
    {
        [JsonProperty("lyrics")]
        public string Lyrics { get; set; }
    }

    public class LyricsRootObject
    {
        public string Lyrics { get; set; }
        public int WordCount { get; set; }
        public IEnumerable<IGrouping<string, string>> Common { get; set; }
    }
}
