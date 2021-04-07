// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/11
// ----------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using Anwalt.Web.Data;
using Anwalt.Web.Data.Models;
using Anwalt.Web.Features.About.Abstractions;
using Anwalt.Web.Features.About.Models;
using Anwalt.Web.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Anwalt.Web.Features.About.Services
{
    public class AboutService : IAboutService
    {
        private readonly AnwaltDbContext _dbContext;

        public AboutService(AnwaltDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AboutResponseModel> GetByLatestModifiedDateAsync() =>
            await _dbContext
                .Abouts
                .OrderByDescending(a => a.ModifiedAt)
                .Select(a => new AboutResponseModel
                {
                    Description = a.Description,
                    Headline = a.Headline,
                    Links = a.Links.Where(l => l.ViewName == "About").Select(l => new AboutLinksResponseModel
                    {
                        Description = l.Description,
                        Id = l.Id,
                        Position = l.Position,
                        Url = l.Url,
                        ViewName = l.ViewName
                    })
                })
                .FirstOrDefaultAsync();

        public async Task<int> CreateAsync(AboutRequestModel model)
        {
            var about = new Data.Models.About
            {
                Description = model.Description,
                Headline = model.Headline,
                Links = model.Links.Select(l => new Link
                {
                    Description = l.Description,
                    Position = l.Position,
                    Url = l.Url,
                    ViewName = l.ViewName
                }).ToList()
            };

            await _dbContext.AddAsync(about);

            await _dbContext.SaveChangesAsync();

            return about.Id;
        }

        public async Task<Result> UpdateAsync(AboutRequestModel model)
        {
            var about = await GetLastAboutAsync();

            if (about == null)
            {
                return "Es ist ein Fehler aufgetreten.";
            }

            about.Description = model.Description;
            about.Headline = model.Headline;

            foreach (var link in model.Links)
            {
                var aboutLink = about.Links.FirstOrDefault(l => l.Id == link.Id);
                aboutLink.Description = link.Description;
                aboutLink.Position = link.Position;
                aboutLink.Url = link.Url;
                aboutLink.ViewName = link.ViewName;
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        private async Task<Data.Models.About> GetLastAboutAsync() =>
            await _dbContext
                .Abouts
                .OrderByDescending(a => a.ModifiedAt)
                .FirstOrDefaultAsync();
    }
}