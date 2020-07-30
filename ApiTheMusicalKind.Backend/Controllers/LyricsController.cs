using System.Net;
using ApiTheMusicalKind.Backend.Models;
using ApiTheMusicalKind.Backend.Services.Lyric;
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
        public ActionResult<CustomLyric> Get(string artist, string title)
        {
            var url = $"{artist}/{title}";

            return Ok(_query.GetCustom(url));
        }

        [HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<int> Count(string artist, string title)
        {
            var url = $"{artist}/{title}";

            return Ok(_query.GetCount(url));
        } 
    }
}