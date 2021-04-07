// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using System.Threading.Tasks;
using Anwalt.Web.Data.Models;
using Anwalt.Web.Features.Abstractions;
using Anwalt.Web.Features.Identity.Abstractions;
using Anwalt.Web.Features.Identity.Models;
using Anwalt.Web.Infrastructure.Models;
using Anwalt.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Anwalt.Web.Features.Identity
{
    [AllowAnonymous]
    public class IdentityController : ApiBaseController
    {
        private readonly UserManager<User> _userManager;

        private readonly ApplicationSettings _applicationSettings;

        private readonly IIdentityService _identityService;

        public IdentityController(UserManager<User> userManager, IOptions<ApplicationSettings> applicationSettings,
            IIdentityService identityService)
        {
            _userManager = userManager;
            _applicationSettings = applicationSettings.Value;
            _identityService = identityService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult<Result>> Register(RegisterUserRequestModel model)
        {
            if (model.Password != model.PasswordRepeat)
            {
                return BadRequest("Password are not equal Password Repeat.");
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return Unauthorized();
            }

            return new LoginResponseModel
            {
                Token = _identityService.GenerateJwtToken(user.Id, model.UserName, _applicationSettings.Secret)
            };
        }
    }
}