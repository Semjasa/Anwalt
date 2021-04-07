// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using System;

namespace Anwalt.Web.Data.Models.Base
{
    public interface IDeletableEntity : IEntity
    {
        DateTime? DeletedAt { get; set; }
        
        string DeletedBy { get; set; }
        
        bool IsDeleted { get; set; }
    }
}