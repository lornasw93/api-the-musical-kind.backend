using System.Net;
using ApiTheMusicalKind.Backend.Models;
using ApiTheMusicalKind.Backend.Services.Search;
using Microsoft.AspNetCore.Mvc;

namespace ApiTheMusicalKind.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _query;

        public SearchController(ISearchService query)
        {
            _query = query;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<Search> Get(string searchTerm)
        {
            return Ok(_query.GetSearch(searchTerm));
        }
    }
}
