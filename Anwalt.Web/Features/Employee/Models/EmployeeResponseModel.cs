﻿// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/13
// ----------------------------------------------------------------------

using System.Collections.Generic;
using Anwalt.Web.Data.Models;

namespace Anwalt.Web.Features.Employee.Models
{
    public class EmployeeResponseModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<EmployeeActivityResponseModel> Activities { get; set; }

        public EmployeeVCardResponseModel VCard { get; set; }
    }
}