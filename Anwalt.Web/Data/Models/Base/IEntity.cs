// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using System;

namespace Anwalt.Web.Data.Models.Base
{
    public interface IEntity
    {
        string CreatedBy { get; set; }

        DateTime CreatedAt { get; set; }

        string ModifiedBy { get; set; }

        DateTime? ModifiedAt { get; set; }
    }
}