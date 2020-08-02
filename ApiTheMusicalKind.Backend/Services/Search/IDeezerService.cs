using System.Threading.Tasks;
using ApiTheMusicalKind.Backend.Models;

namespace ApiTheMusicalKind.Backend.Services.Search
{
    public interface IDeezerService
    {
        Task<Deezer> GetSearchResults(string query);
    }
}
