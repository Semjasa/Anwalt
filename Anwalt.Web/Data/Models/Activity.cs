// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/11
// ----------------------------------------------------------------------

using System.Collections.Generic;
using Anwalt.Web.Data.Models.Base;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Anwalt.Web.Data.Models
{
    public class Activity : DeletableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<EmployeeActivity> EmployeeActivities { get; set; }
    }
}