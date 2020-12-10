using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeStamp.Application.Interfaces;
using TimeStamp.Application.ViewModels;

namespace TimeStamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HackerNewsController : ControllerBase
    {
        private readonly IHackerNewsApp _hackerNewsApp;

        public HackerNewsController(IHackerNewsApp hackerNewsApp)
            => _hackerNewsApp = hackerNewsApp;

        [HttpGet("details-best-stories")]
        public async Task<(List<DetailsBestStoriesVm>, string)> GetDetailsBestStories(int firstTop)
            => await _hackerNewsApp.GetDetailsBestStories(firstTop);
    }
}
