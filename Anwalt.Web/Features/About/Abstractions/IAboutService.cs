// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/11
// ----------------------------------------------------------------------

using System.Threading.Tasks;
using Anwalt.Web.Features.About.Models;
using Anwalt.Web.Infrastructure.Services;

namespace Anwalt.Web.Features.About.Abstractions
{
    public interface IAboutService
    {
        Task<AboutResponseModel> GetByLatestModifiedDateAsync();

        Task<int> CreateAsync(AboutRequestModel model);

        Task<Result> UpdateAsync(AboutRequestModel model);
    }
}