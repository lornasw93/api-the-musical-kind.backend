using Newtonsoft.Json;

namespace ApiTheMusicalKind.Backend.Models
{
    public class Lyric
    {
        [JsonProperty("lyrics")]
        public string Lyrics { get; set; }
    }
}
