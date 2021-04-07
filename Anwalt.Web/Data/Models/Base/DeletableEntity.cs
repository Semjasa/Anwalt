// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using System;

namespace Anwalt.Web.Data.Models.Base
{
    public class DeletableEntity : Entity, IDeletableEntity
    {
        public DateTime? DeletedAt { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}