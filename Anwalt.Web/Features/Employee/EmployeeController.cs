// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/12
// ----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Anwalt.Web.Features.Abstractions;
using Anwalt.Web.Features.Employee.Abstractions;
using Anwalt.Web.Features.Employee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static Anwalt.Web.Infrastructure.WebConstants;

namespace Anwalt.Web.Features.Employee
{
    public class EmployeeController : ApiBaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<List<EmployeesResponseModel>> Get() =>
            await _employeeService
                .GetAsync();

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<EmployeeResponseModel>> Get(int id) =>
            await _employeeService.GetByIdAsync(id);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(EmployeeRequestModel model)
        {
            var id = await _employeeService.CreateAsync(model);

            return Created(nameof(Create), id);
        }

        [HttpPut]
        [Route(Id)]
        [Authorize]
        public async Task<ActionResult> Update(int id, EmployeeRequestModel model)
        {
            var result = await _employeeService.UpdateAsync(id, model);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpDelete]
        [Route(Id)]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _employeeService.DeleteAsync(id);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}