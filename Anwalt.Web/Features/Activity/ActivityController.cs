// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/12
// ----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Anwalt.Web.Data.Models;
using Anwalt.Web.Features.Abstractions;
using Anwalt.Web.Features.Activity.Abstractions;
using Anwalt.Web.Features.Activity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using static Anwalt.Web.Infrastructure.WebConstants;

namespace Anwalt.Web.Features.Activity
{
    public class ActivityController : ApiBaseController
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<List<ActivitiesResponseModel>> GetAsync() =>
            await _activityService.GetAllAsync();

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ActivityResponseModel>> GetAsync(int id) =>
            await _activityService.GetByIdAsync(id);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateAsync(ActivityRequestModel model)
        {
            var id = await _activityService.CreateAsync(model);

            return Created(nameof(CreateAsync), id);
        }

        [HttpPut]
        [Route(Id)]
        [Authorize]
        public async Task<ActionResult> UpdateAsync(int id, ActivityRequestModel model)
        {
            var result = await _activityService.UpdateAsync(id, model);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpDelete]
        [Route(Id)]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _activityService.DeleteAsync(id);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}