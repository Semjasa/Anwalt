// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using Microsoft.Extensions.Configuration;

namespace Anwalt.Web.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration) =>
            configuration.GetConnectionString("DefaultConnection");
    }
}