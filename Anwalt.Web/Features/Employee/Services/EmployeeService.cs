// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/12
// ----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Threading.Tasks;
using Anwalt.Web.Data;
using Anwalt.Web.Data.Models;
using Anwalt.Web.Features.Employee.Abstractions;
using Anwalt.Web.Features.Employee.Models;
using Anwalt.Web.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Anwalt.Web.Features.Employee.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AnwaltDbContext _dbContext;

        public EmployeeService(AnwaltDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EmployeesResponseModel>> GetAsync() =>
            await _dbContext
                .Employees
                .Select(e => new EmployeesResponseModel
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Id = e.Id,
                    JobTitle = e.JobTitle
                })
                .ToListAsync();

        public async Task<EmployeeResponseModel> GetByIdAsync(int id) =>
            await _dbContext
                .Employees
                .Include(e => e.EmployeeActivities)
                .ThenInclude(ea => ea.Activity)
                .Where(e => e.Id == id)
                .Select(e => new EmployeeResponseModel
                {
                    Activities = e
                        .EmployeeActivities
                        .Where(ea => ea.EmployeeId == e.Id)
                        .Select(ea => new EmployeeActivityResponseModel
                        {
                            Id = ea.Activity.Id,
                            Name = ea.Activity.Name
                        }),
                    Description = e.Description,
                    ImageUrl = e.ImageUrl,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    VCard = new EmployeeVCardResponseModel
                    {
                        Id = e.VCard.Id,
                        City = e.VCard.City,
                        Street = e.VCard.Street,
                        PostalCode = e.VCard.PostalCode,
                        Country = e.VCard.Country,
                        Email = e.VCard.Email,
                        FirstName = e.VCard.FirstName,
                        LastName = e.VCard.LastName,
                        Phone = e.VCard.Phone,
                        Mobile = e.VCard.Mobile,
                        JobTitle = e.VCard.JobTitle,
                        Organization = e.VCard.Organization,
                        HomePage = e.VCard.HomePage,
                        Image = e.VCard.Image
                    }
                })
                .FirstOrDefaultAsync();

        public async Task<int> CreateAsync(EmployeeRequestModel model)
        {
            var vCard = new VCard()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                JobTitle = model.JobTitle,
                Organization = model.VCard.Organization,
                Phone = model.VCard.Phone,
                Street = model.VCard.Street,
                PostalCode = model.VCard.PostalCode,
                City = model.VCard.City,
                Country = model.VCard.Country,
                Email = model.VCard.Email,
                HomePage = model.VCard.HomePage,
                Mobile = model.VCard.Mobile
            };

            var employee = new Data.Models.Employee
            {
                Description = model.Description,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ImageUrl = model.ImageUrl,
                JobTitle = model.JobTitle,
                VCard = vCard
            };

            await _dbContext.AddAsync(employee);

            await _dbContext.SaveChangesAsync();

            foreach (var activity in model.Activities)
            {
                var act = await _dbContext
                    .Activities
                    .FirstOrDefaultAsync(a => a.Id == activity.Id);

                var emp = await _dbContext
                    .Employees
                    .FirstOrDefaultAsync(e => e.Id == employee.Id);

                if (act == null || emp == null) continue;
                var empAct = new EmployeeActivity
                {
                    Activity = act,
                    ActivityId = act.Id,
                    Employee = emp,
                    EmployeeId = emp.Id
                };

                await _dbContext.AddAsync(empAct);
            }

            await _dbContext.SaveChangesAsync();

            return employee.Id;
        }

        public async Task<Result> UpdateAsync(int id, EmployeeRequestModel model)
        {
            var employee = await GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return "Ein Fehler ist aufgetreten.";
            }

            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.JobTitle = model.JobTitle;
            employee.Description = model.Description;
            employee.JobTitle = model.JobTitle;
            employee.ImageUrl = model.ImageUrl;
            employee.VCard.FirstName = model.FirstName;
            employee.VCard.LastName = model.LastName;
            employee.VCard.JobTitle = model.JobTitle;
            employee.VCard.Image = model.VCard.Image;
            employee.VCard.Phone = model.VCard.Phone;
            employee.VCard.Mobile = model.VCard.Mobile;
            employee.VCard.Street = model.VCard.Street;
            employee.VCard.PostalCode = model.VCard.PostalCode;
            employee.VCard.City = model.VCard.City;
            employee.VCard.Country = model.VCard.Country;
            employee.VCard.Email = model.VCard.Email;
            employee.VCard.HomePage = model.VCard.HomePage;

            foreach (var activity in model.Activities)
            {
                var act = await _dbContext
                    .EmployeeActivities
                    .FirstOrDefaultAsync(ea => ea.ActivityId == activity.Id && ea.EmployeeId == employee.Id);

                if (act == null)
                {
                    var innerActivity = await _dbContext
                        .Activities
                        .FirstOrDefaultAsync(a => a.Id == activity.Id);

                    var employeeActivity = new EmployeeActivity
                    {
                        Activity = innerActivity,
                        ActivityId = innerActivity.Id,
                        Employee = employee,
                        EmployeeId = employee.Id
                    };
                }
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var employee = await GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return "Der gesuchte Mitarbeiter ist nicht vorhanden.";
            }

            _dbContext.Remove(employee);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        private async Task<Data.Models.Employee> GetEmployeeByIdAsync(int id) =>
            await _dbContext
                .Employees
                .Include(e => e.EmployeeActivities)
                .ThenInclude(ea => ea.Activity)
                .FirstOrDefaultAsync(c => c.Id == id);
    }
}