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
        public IActionResult Get(string searchTerm)
        {
            var response = _service.GetSearchResults(searchTerm);
            if (response.Result == null)
                return NotFound();

            return Ok(response);
        }
    }
}
