// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/12
// ----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Anwalt.Web.Features.Employee.Models;
using Anwalt.Web.Infrastructure.Services;

namespace Anwalt.Web.Features.Employee.Abstractions
{
    public interface IEmployeeService
    {
        Task<List<EmployeesResponseModel>> GetAsync();

        Task<EmployeeResponseModel> GetByIdAsync(int id);

        Task<int> CreateAsync(EmployeeRequestModel model);

        Task<Result> UpdateAsync(int id, EmployeeRequestModel model);

        Task<Result> DeleteAsync(int id);
    }
}