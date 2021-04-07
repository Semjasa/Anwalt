// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/08
// ----------------------------------------------------------------------

using System.Threading.Tasks;
using Anwalt.Web.Features.Home.Models;
using Anwalt.Web.Infrastructure.Services;

namespace Anwalt.Web.Features.Home.Abstractions
{
    public interface IHomeService
    {
        Task<int> CreateAsync(HomeServiceModel model);

        Task<HomeResponseModel> GetByLatestModifiedDateAsync();

        Task<Result> UpdateAsync(HomeServiceModel model);
    }
}