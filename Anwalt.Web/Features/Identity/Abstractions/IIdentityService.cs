// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

namespace Anwalt.Web.Features.Identity.Abstractions
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, string secret);
    }
}