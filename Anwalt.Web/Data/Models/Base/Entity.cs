// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/02
// ----------------------------------------------------------------------

using System;

namespace Anwalt.Web.Data.Models.Base
{
    public class Entity : IEntity
    {
        public string CreatedBy { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public string ModifiedBy { get; set; }
        
        public DateTime? ModifiedAt { get; set; }
    }
}