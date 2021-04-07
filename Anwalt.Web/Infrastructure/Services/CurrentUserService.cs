// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using System.Security.Claims;
using Anwalt.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace Anwalt.Web.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal _user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor) =>
            _user = httpContextAccessor?.HttpContext?.User;

        public string GetUserName() =>
            _user?
                .Identity?
                .Name;

        public string GetId() =>
            _user?
                .GetId();
    }
}