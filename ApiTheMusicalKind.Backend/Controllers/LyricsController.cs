using System.Net;
using ApiTheMusicalKind.Backend.Services.Lyric;
using Microsoft.AspNetCore.Mvc;

namespace ApiTheMusicalKind.Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LyricsController : ControllerBase
    {
        private readonly ILyricService _service;

        public LyricsController(ILyricService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get(string artist, string title)
        {
            var url = $"{artist}/{title}";

            var response = _service.GetLyrics(url);
            if (response.Result == null)
                return NotFound();

            return Ok(response);
        }
    }
}