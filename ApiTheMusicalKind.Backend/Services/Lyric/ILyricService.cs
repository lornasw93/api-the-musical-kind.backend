using System.Threading.Tasks;
using ApiTheMusicalKind.Backend.Models;

namespace ApiTheMusicalKind.Backend.Services.Lyric
{
    public interface ILyricService
    {
        Task<LyricsRootObject> GetLyrics(string resourceUrl);
        //string Get(string resourceUrl);
        //int GetCount(string resourceUrl);
        //CustomLyric GetCustom(string resourceUrl);
    }
}
