// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/11
// ----------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Anwalt.Web.Data.Models.Base;

namespace Anwalt.Web.Data.Models
{
    public class Employee : DeletableEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<EmployeeActivity> EmployeeActivities { get; set; }

        public int VCardId { get; set; }

        public VCard VCard { get; set; }
    }
}