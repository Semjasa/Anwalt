// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using System.Linq;
using System.Security.Claims;

namespace Anwalt.Web.Infrastructure.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetId(this ClaimsPrincipal user) =>
            user
                .Claims
                .FirstOrDefault(u =>
                    u.Type == ClaimTypes.NameIdentifier)?
                .Value;
    }
}