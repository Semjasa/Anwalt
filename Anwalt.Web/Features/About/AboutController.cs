// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/11
// ----------------------------------------------------------------------

using System.Threading.Tasks;
using Anwalt.Web.Features.About.Abstractions;
using Anwalt.Web.Features.About.Models;
using Anwalt.Web.Features.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anwalt.Web.Features.About
{
    public class AboutController : ApiBaseController
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<ActionResult<AboutResponseModel>> Get() =>
            await _aboutService.GetByLatestModifiedDateAsync();

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(AboutRequestModel model)
        {
            var id = await _aboutService.CreateAsync(model);

            return Created(nameof(Create), id);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(AboutRequestModel model)
        {
            var result = await _aboutService.UpdateAsync(model);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}