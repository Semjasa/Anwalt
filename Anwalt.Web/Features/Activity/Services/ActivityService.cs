// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/12
// ----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anwalt.Web.Data;
using Anwalt.Web.Features.Activity.Abstractions;
using Anwalt.Web.Features.Activity.Models;
using Anwalt.Web.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Anwalt.Web.Features.Activity.Services
{
    public class ActivityService : IActivityService
    {
        private readonly AnwaltDbContext _dbContext;

        public ActivityService(AnwaltDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ActivitiesResponseModel>> GetAllAsync() =>
            await _dbContext
                .Activities
                .Where(a => !a.IsDeleted)
                .Select(a => new ActivitiesResponseModel
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToListAsync();

        public async Task<ActivityResponseModel> GetByIdAsync(int id) =>
            await _dbContext
                .Activities
                .Where(a => a.Id == id)
                .Select(a => new ActivityResponseModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description
                })
                .FirstOrDefaultAsync();

        public async Task<int> CreateAsync(ActivityRequestModel model)
        {
            var activity = new Data.Models.Activity
            {
                Description = model.Description,
                Name = model.Name
            };

            await _dbContext.AddAsync(activity);

            await _dbContext.SaveChangesAsync();

            return activity.Id;
        }

        public async Task<Result> UpdateAsync(int id, ActivityRequestModel model)
        {
            var activity = await GetActivityByIdAsync(id);

            if (activity == null)
            {
                return "Das gesuchte Fachgebiet ist nicht vorhanden.";
            }

            activity.Name = model.Name;
            activity.Description = model.Description;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var activity = await GetActivityByIdAsync(id);

            if (activity == null)
            {
                return "Das gesuchte Fachgebiet ist nicht vorhanden.";
            }

            _dbContext.Remove(activity);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        private async Task<Data.Models.Activity> GetActivityByIdAsync(int id) =>
            await _dbContext
                .Activities
                .FirstOrDefaultAsync(a => a.Id == id);
    }
}