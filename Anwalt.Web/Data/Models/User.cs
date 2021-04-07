// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using System;
using Anwalt.Web.Data.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace Anwalt.Web.Data.Models
{
    public class User : IdentityUser, IEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public string ModifiedBy { get; set; }
        
        public DateTime? ModifiedAt { get; set; }

        public Profile Profile { get; set; }
    }
}