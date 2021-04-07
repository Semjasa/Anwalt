// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/15
// ----------------------------------------------------------------------

namespace Anwalt.Web.Features.Employee.Models
{
    public class EmployeesResponseModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }
    }
}