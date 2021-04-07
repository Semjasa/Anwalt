// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/12
// ----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Anwalt.Web.Features.Activity.Models;
using Anwalt.Web.Infrastructure.Services;

namespace Anwalt.Web.Features.Activity.Abstractions
{
    public interface IActivityService
    {
        Task<List<ActivitiesResponseModel>> GetAllAsync();

        Task<ActivityResponseModel> GetByIdAsync(int id);

        Task<int> CreateAsync(ActivityRequestModel model);

        Task<Result> UpdateAsync(int id, ActivityRequestModel model);

        Task<Result> DeleteAsync(int id);
    }
}