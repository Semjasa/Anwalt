// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/07
// ----------------------------------------------------------------------

using System.Threading.Tasks;
using Anwalt.Web.Features.Abstractions;
using Anwalt.Web.Features.Home.Abstractions;
using Anwalt.Web.Features.Home.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anwalt.Web.Features.Home
{
    public class HomeController : ApiBaseController
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public async Task<ActionResult<HomeResponseModel>> Get() =>
            await _homeService.GetByLatestModifiedDateAsync();

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(HomeServiceModel model)
        {
            var id = await _homeService.CreateAsync(model);

            return Created(nameof(Create), id);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(HomeServiceModel model)
        {
            var result = await _homeService.UpdateAsync(model);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}