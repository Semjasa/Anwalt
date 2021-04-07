// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/15
// ----------------------------------------------------------------------

namespace Anwalt.Web.Features.Employee.Models
{
    public class EmployeeVCardResponseModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public string Organization { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string HomePage { get; set; }

        public byte[] Image { get; set; }
    }
}