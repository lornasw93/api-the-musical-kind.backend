using System.Net;
using ApiTheMusicalKind.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTheMusicalKind.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LyricsController : ControllerBase
    {
        private readonly ILyricService _query;

        public LyricsController(ILyricService query)
        {
            _query = query;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<string> Get(string artist, string title)
        {
            var url = $"{artist}/{title}";

            return Ok(_query.Get(url));
        }
    }
}