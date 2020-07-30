using System.Threading.Tasks;

namespace ApiTheMusicalKind.Backend.Services.Search
{
    public interface ISearchService
    {
        Task<Models.Search> Get(string resourceUrl);
    }
}
