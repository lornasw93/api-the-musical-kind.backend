using System.Net;
using ApiTheMusicalKind.Backend.Models;
using ApiTheMusicalKind.Backend.Services.Search;
using Microsoft.AspNetCore.Mvc;

namespace ApiTheMusicalKind.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DeezerController : ControllerBase
    {
        private readonly IDeezerService _service;

        public DeezerController(IDeezerService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<Deezer> Get(string searchTerm)
        {
            return Ok(_service.GetSearchResults(searchTerm));
        }
    }
}
