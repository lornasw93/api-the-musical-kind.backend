using System.Threading.Tasks; 

namespace ApiTheMusicalKind.Backend.Services.Lyric
{
    public interface ILyricService
    {
        Task<object> GetLyrics(string resourceUrl);

      
        //string Get(string resourceUrl);
        //int GetCount(string resourceUrl);
        //CustomLyric GetCustom(string resourceUrl);
    }
}
