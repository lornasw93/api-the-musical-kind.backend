using System.Threading.Tasks;
using ApiTheMusicalKind.Backend.Models;

namespace ApiTheMusicalKind.Backend.Services.Lyric
{
    public interface ILyricService
    {
        Task<string> Get(string resourceUrl);
        Task<int> GetCount(string resourceUrl);
        Task<CustomLyric> GetCustom(string resourceUrl);
    }
}
