// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

namespace Anwalt.Web.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        string GetUserName();

        string GetId();
    }
}