// ----------------------------------------------------------------------
// Thomas Heise
// Anwalt
// Anwalt.Web
// 2021/03/12
// ----------------------------------------------------------------------

namespace Anwalt.Web.Data.Models
{
    public class EmployeeActivity
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int ActivityId { get; set; }

        public Activity Activity { get; set; }
    }
}