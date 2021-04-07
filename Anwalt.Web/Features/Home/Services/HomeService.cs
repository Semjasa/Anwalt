// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/08
// ----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anwalt.Web.Data;
using Anwalt.Web.Data.Models;
using Anwalt.Web.Features.Home.Abstractions;
using Anwalt.Web.Features.Home.Models;
using Anwalt.Web.Infrastructure.Services;
using Anwalt.Web.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Anwalt.Web.Features.Home.Services
{
    public class HomeService : IHomeService
    {
        private readonly AnwaltDbContext _dbContext;

        public HomeService(AnwaltDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> CreateAsync(HomeServiceModel model)
        {
            var home = new Data.Models.Home
            {
                Cards = model.Cards.Select(c => new Card
                {
                    Description = c.Description,
                    Headline = c.Headline,
                    ImageUrl = c.ImageUrl
                }).ToList(),
                Description = model.Description,
                Headline = model.Headline
            };

            await _dbContext.AddAsync(home);

            await _dbContext.SaveChangesAsync();

            return home.Id;
        }

        public async Task<HomeResponseModel> GetByLatestModifiedDateAsync() =>
            await _dbContext
                .Homes
                .OrderByDescending(h => h.ModifiedAt)
                .Select(h => new HomeResponseModel
                {
                    Id = h.Id,
                    Cards = h
                        .Cards
                        .Where(c => c.HomeId == h.Id)
                        .Select(c => new HomeCardModel
                        {
                            Headline = c.Headline,
                            Description = c.Description,
                            Id = c.Id,
                            ImageUrl = c.ImageUrl
                        }).ToList(),
                    Headline = h.Headline,
                    Description = h.Description
                })
                .FirstOrDefaultAsync();
            

        public async Task<Result> UpdateAsync(HomeServiceModel model)
        {
            var home = await GetLatestHomeEntryAsync();

            if (home == null)
            {
                return "Ein Fehler ist aufgetreten.";
            }

            foreach (var card in model.Cards)
            {
                var innerCard = home.Cards.FirstOrDefault(c => c.Id == card.Id);
                innerCard.Headline = card.Headline;
                innerCard.Description = card.Description;
                innerCard.ImageUrl = card.ImageUrl;
            }

            home.Description = model.Description;
            home.Headline = model.Headline;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        private async Task<Data.Models.Home> GetLatestHomeEntryAsync() =>
            await _dbContext
                .Homes
                .OrderByDescending(h => h.ModifiedAt)
                .FirstOrDefaultAsync();
    }
}