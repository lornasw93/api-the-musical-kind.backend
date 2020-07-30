using ApiTheMusicalKind.Backend.Models;

namespace ApiTheMusicalKind.Backend.Services.Lyric
{
    public interface ILyricService
    {
        //string Get(string resourceUrl);
        //int Count(string resourceUrl);
        string Get(string resourceUrl);
        int GetCount(string resourceUrl);
        CustomLyric GetCustom(string resourceUrl);
    }
}
